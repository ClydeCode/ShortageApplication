using ShortageApplication;

ShortageController Program = new();

while (true)
{
	Program.ShowMenu();

	Program.Navigate(UserInput.GetInt());

	Console.WriteLine("\nPress ENTER to Continue...");
	Console.ReadLine();
}
