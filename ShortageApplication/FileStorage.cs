using System.Text.Json;

namespace ShortageApplication
{
	internal class FileStorage
	{
		private readonly string _fileName;

		public FileStorage(string fileName)
		{
			_fileName = fileName;
		}

		public void SaveData(List<ShortageModel> list)
		{
			string jsonString = JsonSerializer.Serialize(list);

			File.WriteAllText(_fileName, jsonString);
		}

		public List<ShortageModel>? GetData()
		{
			if (!File.Exists(_fileName)) return new List<ShortageModel>();

			string jsonString = File.ReadAllText(_fileName);

			return JsonSerializer.Deserialize<List<ShortageModel>>(jsonString);
		}
	}
}
