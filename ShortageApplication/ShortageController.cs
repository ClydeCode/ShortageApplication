
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
					List();
					break;
				case 2:
					Register();
					break;
				case 3:
					Delete();
					break;
				default:
					Console.WriteLine("Wrong option!");
					break;
			}
		}

		private void List()
		{
			List<ShortageModel> tempList = _shortages;

			Console.WriteLine("Would you like to filter list?");
			Console.WriteLine("1. Filter by Title");
			Console.WriteLine("2. Filter by Date");
			Console.WriteLine("3. Filter by Category");
			Console.WriteLine("4. Filter by Room");
			Console.WriteLine("5. Don't use any filters");

			int option = UserInput.GetBetweenInt(1, 5, "option");

			switch (option)
			{
				case 1:
					tempList = FilterByTitle(tempList, UserInput.GetString("title"));
					break;
				case 2:
					DateTime startDate = UserInput.GetDate();
					DateTime endDate = UserInput.GetDate(startDate);
					tempList = FilterByDate(tempList, startDate, endDate);
					break;
				case 3:
					tempList = FilterByCategory(_shortages, UserInput.GetOption(new string[] { "Electronics", "Food", "Other" }));
					break;
				case 4:
					tempList = FilterByRoom(_shortages, UserInput.GetOption(new string[] { "meeting room", "kitchen", "bathroom" }));
					break;
				case 5:
					break;
				default:
					Console.WriteLine("Wrong option!");
					break;
			}

			if (_name != "administrator") tempList = FilterByName(tempList);

			foreach (var item in tempList)
			{
				Console.WriteLine($"{item.Id} {item.Title} {item.Room} {item.Category} {item.Priority} {item.CreatedOn}");
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

		private void Delete()
		{
			int id = UserInput.GetInt("id");

			var obj = _shortages.Find(item => item.Id == id);

			if (obj != null)
			{
				if (obj.Name != _name && _name != "administrator")
				{
					Console.WriteLine("You don't have required permissions to do that!");

					return;
				}
			}
			else
				return;

			_shortages.Remove(obj);

			FileStorage.SaveData(_shortages);
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

			_shortages = SortByPriority(_shortages);
			FileStorage.SaveData(_shortages);
		}

		private List<ShortageModel> FilterByTitle(List<ShortageModel> shortages, string word)
		{
			return shortages.Where(item => item.Title.Split(new char[] { ' ' }).Contains(word)).ToList();
		}

		private List<ShortageModel> FilterByName(List<ShortageModel> shortages)
		{
			return shortages.Where(item => item.Name == _name).ToList();
		}

		private List<ShortageModel> FilterByDate(List<ShortageModel> shortages, DateTime startDate, DateTime endDate)
		{
			return shortages.Where(item => startDate <= item.CreatedOn && item.CreatedOn <= endDate).ToList();
		}

		private List<ShortageModel> FilterByCategory(List<ShortageModel> shortages, string category)
		{
			return shortages.Where(item => item.Category == category).ToList();
		}

		private List<ShortageModel> FilterByRoom(List<ShortageModel> shortages, string room)
		{
			return shortages.Where(item => item.Room == room).ToList();
		}

		private List<ShortageModel> SortByPriority(List<ShortageModel> shortages)
		{
			return shortages.OrderByDescending(item => item.Priority).ToList();
		}
	}
}
