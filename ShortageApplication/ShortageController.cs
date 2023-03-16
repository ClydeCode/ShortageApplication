
namespace ShortageApplication
{
	internal class ShortageController
	{
		UserInput UserInput = new();

		private string _name;

		public ShortageController()
		{
			_name = UserInput.GetString("name");
		}

		public void ShowMenu()
		{
			Console.Clear();
			Console.WriteLine("\nMain Menu");
			Console.WriteLine("\nWhat would you like to do:");
			Console.WriteLine("\nType 0 To Close Application");
			Console.WriteLine("Type 1 To View All Requests");
			Console.WriteLine("Type 2 To Register a new Request");
			Console.WriteLine("Type 3 To Delete a Request");
		}

		public void Navigate(int number)
		{
			Console.Clear();

			switch (number)
			{
				case 0:
					Environment.Exit(0);
					break;
				case 1:
					break;
				case 2:
					break;
				case 3:
					break;
				default:
					Console.WriteLine("Wrong option!");
					break;
			}
		}
	}
}
