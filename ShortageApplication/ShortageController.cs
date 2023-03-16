
namespace ShortageApplication
{
	internal class ShortageController
	{
		private readonly FileStorage FileStorage = new();
		private readonly UserInput UserInput = new();

		private List<ShortageModel>? _shortages = new();
		private string _name;

		public ShortageController()
		{
			_shortages = FileStorage.GetData();
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
					Register();
					break;
				case 3:
					break;
				default:
					Console.WriteLine("Wrong option!");
					break;
			}
		}

		private void Register()
		{
			int id = _shortages.Count;
			string title = UserInput.GetString("title");
			string name = _name;
			string room = UserInput.GetOption(new string[] { "meeting room", "kitchen", "bathroom" });
			string category = UserInput.GetOption(new string[] { "Electronics", "Food", "Other" });
			int priority = UserInput.GetBetweenInt(1, 10, "priority");
			DateTime createdOn = DateTime.Now;

			var obj = new ShortageModel
			{
				Id = id,
				Title = title,
				Name = name,
				Room = room,
				Category = category,
				Priority = priority,
				CreatedOn = createdOn
			};

			AddObjToList(obj);
		}

		private void AddObjToList(ShortageModel newObj)
		{
			ShortageModel? tempObj = _shortages.Find(item => item.Title == newObj.Title);

			if (tempObj != null && tempObj.Room == newObj.Room)
			{
				if (tempObj.Priority < newObj.Priority) tempObj.Priority = newObj.Priority;
				else
					Console.WriteLine("This item already exists!");
			}
			else
				_shortages.Add(newObj);

			FileStorage.SaveData(_shortages);
		}
	}
}
