
namespace ShortageApplication
{
	internal class Filters
	{
		public List<ShortageModel> FilterByTitle(List<ShortageModel> shortages, string word)
		{
			return shortages.Where(item => item.Title.Split(new char[] { ' ' }).Contains(word)).ToList();
		}

		public List<ShortageModel> FilterByName(List<ShortageModel> shortages, string name)
		{
			return shortages.Where(item => item.Name == name).ToList();
		}

		public List<ShortageModel> FilterByDate(List<ShortageModel> shortages, DateTime startDate, DateTime endDate)
		{
			return shortages.Where(item => startDate <= item.CreatedOn && item.CreatedOn <= endDate).ToList();
		}

		public List<ShortageModel> FilterByCategory(List<ShortageModel> shortages, string category)
		{
			return shortages.Where(item => item.Category == category).ToList();
		}

		public List<ShortageModel> FilterByRoom(List<ShortageModel> shortages, string room)
		{
			return shortages.Where(item => item.Room == room).ToList();
		}
	}
}
