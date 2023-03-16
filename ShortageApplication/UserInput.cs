
using System.Text.RegularExpressions;

namespace ShortageApplication
{
	internal class UserInput
	{
		public int GetInt(string title = "number")
		{
			Console.WriteLine($"\nType {title}:");

			string? number = Console.ReadLine();

			while (!int.TryParse(number, out _))
			{
				Console.WriteLine("Wrong number format!");
				number = Console.ReadLine();
			}

			return int.Parse(number);
		}

		public int GetBetweenInt(int number1, int number2, string title)
		{
			int number = GetInt(title);

			while (!(number > number1 - 1 && number < number2 + 1))
			{
				Console.WriteLine($"Number has to be between {number1} and {number2}");

				number = GetInt(title);
			}

			return number;
		}

		public string GetOption(string[] array, string title = "number")
		{
			Console.WriteLine($"\n1. {array[0]} \n2. {array[1]} \n3. {array[2]}");

			int number = GetBetweenInt(1, 3, title);

			return array[number - 1];
		}

		public string GetString(string title)
		{
			Console.WriteLine($"\nType {title}:");

			string? text = Console.ReadLine();

			while (!Regex.IsMatch(text, @"^[a-zA-Z0-9_]+$") && text == null)
			{
				Console.WriteLine("Wrong text format!");
				text = Console.ReadLine();
			}

			return text;
		}

		public DateTime GetDate(DateTime startDate = new())
		{
			string? date;

			while (true)
			{
				Console.WriteLine("Type Date <yyyy-MM-dd>:");
				date = Console.ReadLine();

				if (!DateTime.TryParse(date, out _))
				{
					Console.WriteLine("Wrong Date Format!");
					continue;
				}

				if (!(DateTime.Parse(date).CompareTo(startDate) > 0))
					Console.WriteLine("EndTime can't be earlier than StartTime!");
				else
					break;
			}

			return DateTime.Parse(date);
		}
	}
}
