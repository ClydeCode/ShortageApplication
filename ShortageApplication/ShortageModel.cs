
namespace ShortageApplication
{
	internal class ShortageModel
	{
		public int Id { get; set; }
		public string? Title { get; set; }
		public string? Name { get; set; }
		public string? Room { get; set; }
		public string? Category { get; set; }
		public int Priority { get; set; }
		public DateTime CreatedOn { get; set; }
	}
}
