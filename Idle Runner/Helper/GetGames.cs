namespace Idle_Runner.Helper
{
    public class GetGames
    {
        public List<Game> GetInstalledGames(Label statusLabel)
        {

            try 
            {
                statusLabel.ForeColor = Color.Yellow;
                statusLabel.Text = "Getting Games...";

                HashSet<Game> games = new HashSet<Game>(new GameComparer());

                string steamPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Steam");
                string libraryFile = Path.Combine(steamPath, "steamapps", "libraryfolders.vdf");

                if (!File.Exists(libraryFile))
                {
                    MessageBox.Show("Steam Library File doesn't exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return games.ToList();
                }

                var libraryPaths = ExtractLibraryPaths(steamPath, libraryFile);

                foreach (var libraryPath in libraryPaths)
                {
                    string steamAppsFolder = Path.Combine(libraryPath, "steamapps");
                    if (Directory.Exists(steamAppsFolder))
                    {
                        ProcessLibraryFolder(steamAppsFolder, games);
                    }
                }

                statusLabel.ForeColor = Color.Green;
                statusLabel.Text = "Added games to list!";
                return games.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving games:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Game>();
            }
        }

        private List<string> ExtractLibraryPaths(string steamPath, string libraryFile)
        {
            List<string> libraryPaths = new() { steamPath };
            string[] lines = File.ReadAllLines(libraryFile);

            foreach (var line in lines)
            {
                if (line.Contains("path"))
                {
                    string path = line.Split('"')[3];
                    libraryPaths.Add(path);
                }
            }

            return libraryPaths;
        }

        private void ProcessLibraryFolder(string steamAppsFolder, HashSet<Game> games)
        {
            foreach (var file in Directory.GetFiles(steamAppsFolder, "appmanifest_*.acf"))
            {
                string[] lines = File.ReadAllLines(file);
                string appIdLine = lines.FirstOrDefault(line => line.Contains("appid"));
                string nameLine = lines.FirstOrDefault(line => line.Contains("name"));

                if (!string.IsNullOrEmpty(appIdLine) && !string.IsNullOrEmpty(nameLine))
                {
                    int appId = int.Parse(appIdLine.Split('"')[3]);
                    string gameName = nameLine.Split('"')[3];
                    games.Add(new Game(appId, gameName));
                }
            }
        }
    }

    public class Game
    {
        public int AppId { get; set; }
        public string Name { get; set; }

        public Game(int appId, string name)
        {
            AppId = appId;
            Name = name;
        }
    }

    public class GameComparer : IEqualityComparer<Game>
    {
        public bool Equals(Game x, Game y) => x?.AppId == y?.AppId;

        public int GetHashCode(Game obj) => obj.AppId.GetHashCode();
    }
}
