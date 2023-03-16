
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
	}
}
