
namespace ShortageApplication
{
	static class Data
	{
		static public List<ShortageModel> FilterByTitle(List<ShortageModel> shortages, string word)
		{
			return shortages.Where(item => item.Title.ToLower().Split(new char[] { ' ' }).Contains(word.ToLower())).ToList();
		}

		static public List<ShortageModel> FilterByName(List<ShortageModel> shortages, string name)
		{
			return shortages.Where(item => item.Name.ToLower() == name.ToLower()).ToList();
		}

		static public List<ShortageModel> FilterByDate(List<ShortageModel> shortages, DateTime startDate, DateTime endDate)
		{
			return shortages.Where(item => startDate <= item.CreatedOn && item.CreatedOn <= endDate).ToList();
		}

		static public List<ShortageModel> FilterByCategory(List<ShortageModel> shortages, string category)
		{
			return shortages.Where(item => item.Category.ToLower() == category.ToLower()).ToList();
		}

		static public List<ShortageModel> FilterByRoom(List<ShortageModel> shortages, string room)
		{
			return shortages.Where(item => item.Room.ToLower() == room.ToLower()).ToList();
		}

		static public List<ShortageModel> SortByPriority(List<ShortageModel> shortages)
		{
			return shortages.OrderByDescending(item => item.Priority).ToList();
		}
	}
}
