
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
	}
}
