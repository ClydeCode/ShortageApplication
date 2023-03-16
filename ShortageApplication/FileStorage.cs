using System.Text.Json;

namespace ShortageApplication
{
	internal class FileStorage
	{
		private string _fileName = "shortageData.json";

		public void SaveData(List<ShortageModel> list)
		{
			string jsonString = JsonSerializer.Serialize(list);

			File.WriteAllText(_fileName, jsonString);
		}
	}
}
