using Newtonsoft.Json.Linq;
using ShortageApplication;

namespace TestApplication
{
	[TestClass]
	public class TestUserInput
	{
		[DataTestMethod]
		[DataRow("1")]
		[DataRow("50")]
		[DataRow("100")]
		public void GetInt_InputCorrectNumber_ReturnsNumber(string value)
		{
			using (var reader = new StringReader(value))
			{
				Console.SetIn(reader);

				int actual = UserInput.GetInt();
				int expected = int.Parse(value);

				Assert.AreEqual(expected, actual);
			}
		}

		[DataTestMethod]
		[DataRow("sd\n50")]
		[DataRow("#@!\n50")]
		public void GetInt_InputIncorrectNumber_WritesMessage(string value)
		{
			using (var reader = new StringReader(value))
			using (var writer = new StringWriter())
			{
				Console.SetIn(reader);
				Console.SetOut(writer);

				_ = UserInput.GetInt();

				string actualMessage = writer.ToString();
				string expectedMessage = "Wrong number format!";

				Assert.IsTrue(actualMessage.Contains(expectedMessage));
			}
		}

		[DataTestMethod]
		[DataRow("10")]
		[DataRow("15")]
		[DataRow("20")]
		public void GetBetweenInt_InputCorrectNumber_ReturnsNumber(string value)
		{
			using (var reader = new StringReader(value))
			{
				Console.SetIn(reader);

				int actual = UserInput.GetBetweenInt(10, 20);
				int expected = int.Parse(value);

				Assert.AreEqual(expected, actual);
			}
		}

		[DataTestMethod]
		[DataRow("21\n15")]
		[DataRow("28\n15")]
		[DataRow("1\n15")]
		public void GetBetweenInt_InputIncorrectNumber_WritesMessage(string value)
		{
			using (var reader = new StringReader(value))
			using (var writer = new StringWriter())
			{
				Console.SetIn(reader);
				Console.SetOut(writer);

				_ = UserInput.GetBetweenInt(10, 20);

				string actualMessage = writer.ToString();
				string expectedMessage = "Number has to be between";

				Assert.IsTrue(actualMessage.Contains(expectedMessage));
			}
		}

		[DataTestMethod]
		[DataRow("1")]
		[DataRow("2")]
		[DataRow("3")]
		public void GetOption_InputCorrectNumber_ReturnsString(string value)
		{
			string[] array = { "Electronics", "Food", "Other"};

			using (var reader = new StringReader(value))
			{
				Console.SetIn(reader);

				string actual = UserInput.GetOption(new string[] {"Electronics", "Food", "Other"});
				string expected = array[int.Parse(value) - 1];

				Assert.AreEqual(expected, actual);
			}
		}

		[DataTestMethod]
		[DataRow("1")]
		[DataRow("Car")]
		[DataRow("method123_")]
		public void GetString_InputCorrectString_ReturnsString(string value)
		{
			using (var reader = new StringReader(value))
			{
				Console.SetIn(reader);

				string actual = UserInput.GetString();
				string expected = value;

				Assert.AreEqual(value, actual);
			}
		}

		[DataTestMethod]
		[DataRow("%$#\ntext")]
		[DataRow("Car@\ntext")]
		[DataRow("method123!!\ntext")]
		public void GetString_InputIncorrectString_WritesMessage(string value)
		{
			using (var reader = new StringReader(value))
			using (var writer = new StringWriter())
			{
				Console.SetIn(reader);
				Console.SetOut(writer);

				_ = UserInput.GetString();

				string actualMessage = writer.ToString();
				string expectedMessage = "Wrong text format!";

				Assert.IsTrue(actualMessage.Contains(expectedMessage));
			}
		}

		[DataTestMethod]
		[DataRow("2023-01-01")]
		[DataRow("2000-01")]
		public void GetDate_InputCorrectDate_1_ReturnsDate(string value)
		{
			using (var reader = new StringReader(value))
			{
				Console.SetIn(reader);

				DateTime actual = UserInput.GetDate();
				DateTime expected = DateTime.Parse(value);

				Assert.AreEqual(expected, actual);
			}
		}

		[DataTestMethod]
		[DataRow("2023-01-01")]
		[DataRow("2023-07")]
		public void GetDate_InputCorrectDate_2_ReturnsDate(string value)
		{
			using (var reader = new StringReader(value))
			{
				Console.SetIn(reader);

				DateTime actual = UserInput.GetDate(new DateTime(2023-01-01));
				DateTime expected = DateTime.Parse(value);

				Assert.AreEqual(expected, actual);
			}
		}

		[DataTestMethod]
		[DataRow("2023-01-01@\n2023-01-01")]
		[DataRow("2023-07!\n2023-01-01")]
		[DataRow("2023\n2023-01-01")]
		public void GetDate_InputIncorrectDate_1_WritesMessage(string value)
		{
			using (var reader = new StringReader(value))
			using (var writer = new StringWriter())
			{
				Console.SetIn(reader);
				Console.SetOut(writer);

				_ = UserInput.GetDate();

				string actualMessage = writer.ToString();
				string expectedMessage = "Wrong Date Format!";

				Assert.IsTrue(actualMessage.Contains(expectedMessage));
			}
		}

		[DataTestMethod]
		[DataRow("2022-01-01\n2023-01-01")]
		[DataRow("2022-07\n2023-01-01")]
		[DataRow("2022-09\n2023-01-01")]
		public void GetDate_InputIncorrectDate_2_WritesMessage(string value)
		{
			using (var reader = new StringReader(value))
			using (var writer = new StringWriter())
			{
				Console.SetIn(reader);
				Console.SetOut(writer);

				_ = UserInput.GetDate(new DateTime(2023, 01, 01));

				string actualMessage = writer.ToString();
				string expectedMessage = "EndTime can't be earlier than StartTime!";

				Assert.IsTrue(actualMessage.Contains(expectedMessage));
			}
		}
	}
}
