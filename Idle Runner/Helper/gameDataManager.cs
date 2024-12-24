using Newtonsoft.Json;

namespace Idle_Runner.Helper 
{
    public class GameData
    {
        public long AppId { get; set; }
        public string Name { get; set; }
        public DateTime? LastIdle { get; set; }
        public double IdleHours { get; set; }
    }

    public class GameDataManager
    {
        private readonly string dataFilePath;

        public GameDataManager()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string targetDirectory = Path.Combine(documentsPath, "Idle Runner");

            Directory.CreateDirectory(targetDirectory);
            dataFilePath = Path.Combine(targetDirectory, "GameData.json");
        }

        public List<GameData> LoadData()
        {
            try
            {
                if (File.Exists(dataFilePath))
                {
                    string json = File.ReadAllText(dataFilePath);
                    return JsonConvert.DeserializeObject<List<GameData>>(json) ?? new List<GameData>();
                }

                return new List<GameData>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading game data:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<GameData>();
            }
        }

        public void SaveData(List<GameData> gameData)
        {
            try
            {
                string json = JsonConvert.SerializeObject(gameData, Formatting.Indented);
                File.WriteAllText(dataFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving game data:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateGameData(List<Game> installedGames)
        {
            try
            {
                var gameDataList = LoadData();

                foreach (var installedGame in installedGames)
                {
                    var existingGame = gameDataList.FirstOrDefault(g => g.AppId == installedGame.AppId);
                    if (existingGame == null)
                    {
                        gameDataList.Add(new GameData
                        {
                            AppId = installedGame.AppId,
                            Name = installedGame.Name,
                            LastIdle = null,
                            IdleHours = 0
                        });
                    }
                }

                SaveData(gameDataList);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating game data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}