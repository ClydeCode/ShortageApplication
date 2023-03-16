using ShortageApplication;

ShortageController Program = new();
UserInput UserInput = new();

while (true)
{
	Program.ShowMenu();

	Program.Navigate(UserInput.GetInt());

	Console.WriteLine("\nPress ENTER to Continue...");
	Console.ReadLine();
}
