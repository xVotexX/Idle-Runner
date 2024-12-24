using System.Diagnostics;

namespace Idle_Runner.Helper
{
    public class IdleProcessMonitor
    {
        private readonly GameDataManager _gameDataManager;
        private readonly Dictionary<long, (string Name, Process ProcessInstance)> _runningProcesses;

        public IdleProcessMonitor()
        {
            _gameDataManager = new GameDataManager();
            _runningProcesses = new Dictionary<long, (string Name, Process ProcessInstance)>();
        }

        public Dictionary<long, (string Name, Process ProcessInstance)> GetRunningProcesses()
        {
            return new Dictionary<long, (string Name, Process ProcessInstance)>(_runningProcesses);
        }

        public async Task MonitorProcessAsync(Game selectedGame, CheckBox checkBox)
        {
            string gameIdlerPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Game-Idler.exe");
            string arguments = $"{selectedGame.AppId} \"{selectedGame.Name}\" {(checkBox.Checked ? "true" : "false")}";


            ProcessStartInfo startInfo = new()
            {
                FileName = gameIdlerPath,
                Arguments = arguments,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using Process process = Process.Start(startInfo);
            DateTime startTime = DateTime.Now;

            _runningProcesses[selectedGame.AppId] = (selectedGame.Name, process);

            await Task.Run(() =>
            {
                process.WaitForExit();

                double secondsRunning = (DateTime.Now - startTime).TotalSeconds;
                _runningProcesses.Remove(selectedGame.AppId);

                var gameDataList = _gameDataManager.LoadData();
                var gameData = gameDataList.FirstOrDefault(g => g.AppId == selectedGame.AppId);

                if (gameData != null)
                {
                    gameData.IdleHours += secondsRunning;
                    gameData.LastIdle = DateTime.Now;
                    _gameDataManager.SaveData(gameDataList);
                }
            });
        }
    }
}