using ShortageApplication;

namespace TestApplication
{
	[TestClass]
	public class TestData
	{
		private List<ShortageModel> _shortages = new List<ShortageModel>
		{
			new ShortageModel{ Id = 0, Title = "Brick Wall", Name = "clyde", Room = "kitchen", Category = "Other", Priority = 6, CreatedOn = new DateTime(2023, 01, 01)},
			new ShortageModel{ Id = 1, Title = "Brick", Name = "clyde", Room = "kitchen", Category = "Other", Priority = 3, CreatedOn = new DateTime(2023, 02, 01)},
			new ShortageModel{ Id = 2, Title = "Bricks", Name = "administrator", Room = "kitchen", Category = "Other", Priority = 4, CreatedOn = new DateTime(2023-02-05)}
		};

		[TestMethod]
		public void FilterByTitle_InputIsBrick_Return2values()
		{
			var result = Data.FilterByTitle(_shortages, "Brick");

			Assert.AreEqual(2, result.Count);
		}

		[TestMethod]
		public void FilterByTitle_InputIsBri_Return0values()
		{
			var result = Data.FilterByTitle(_shortages, "bri");

			Assert.AreEqual(0, result.Count);
		}

		[TestMethod]
		public void FilterByName_InputIsClyde_Return2values()
		{
			var result = Data.FilterByName(_shortages, "clyde");

			Assert.AreEqual(2, result.Count);
		}

		[TestMethod]
		public void FilterByName_InputIsAdministrator_Return1values()
		{
			var result = Data.FilterByName(_shortages, "Administrator");

			Assert.AreEqual(1, result.Count);
		}

		[TestMethod]
		public void FilterByDate_InputIs2023_01_01and2023_02_01_Return2values()
		{
			var result = Data.FilterByDate(_shortages, new DateTime(2023, 01, 01), new DateTime(2023, 02, 01));

			Assert.AreEqual(2, result.Count);
		}

		[TestMethod]
		public void FilterByCategory_InputIsOther_Return3values()
		{
			var result = Data.FilterByCategory(_shortages, "Other");

			Assert.AreEqual(3, result.Count);
		}

		[TestMethod]
		public void FilterByCategory_InputIsOthe_Return0values()
		{
			var result = Data.FilterByCategory(_shortages, "othe");

			Assert.AreEqual(0, result.Count);
		}

		[TestMethod]
		public void FilterByRoom_InputIsKitchen_Return3values()
		{
			var result = Data.FilterByRoom(_shortages, "Kitchen");

			Assert.AreEqual(3, result.Count);
		}

		[TestMethod]
		public void FilterByRoom_InputIsFood_Return0values()
		{
			var result = Data.FilterByRoom(_shortages, "food");

			Assert.AreEqual(0, result.Count);
		}
	}
}