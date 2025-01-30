using System.Diagnostics;
using Idle_Runner.Discord;

namespace Idle_Runner.Helper
{
    public class IdleProcessMonitor
    {
        private readonly ConfigManager config;
        private readonly GameDataManager _gameDataManager;
        private readonly Dictionary<long, (string Name, Process ProcessInstance)> _runningProcesses;
        private readonly RPC discordRPCManager;

        public IdleProcessMonitor(ConfigManager config, RPC discordRPCManager)
        {
            _gameDataManager = new GameDataManager();
            _runningProcesses = new Dictionary<long, (string Name, Process ProcessInstance)>();
            this.config = config;
            this.discordRPCManager = discordRPCManager;
        }

        public Dictionary<long, (string Name, Process ProcessInstance)> GetRunningProcesses()
        {
            return new Dictionary<long, (string Name, Process ProcessInstance)>(_runningProcesses);
        }

        public async Task MonitorProcessAsync(Game selectedGame)
        {
            string gameIdlerPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Game-Idler.exe");
            string arguments = $"{selectedGame.AppId} \"{selectedGame.Name}\" {(config.HideIdleCheck ? "true" : "false")}";

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

                try
                {
                    double secondsRunning = (DateTime.Now - startTime).TotalSeconds;
                    _runningProcesses.Remove(selectedGame.AppId);

                    var newProcesses = GetRunningProcesses();
                    discordRPCManager.UpdatePresence(newProcesses.Count);

                    var gameDataList = _gameDataManager.LoadData();
                    var gameData = gameDataList.FirstOrDefault(g => g.AppId == selectedGame.AppId);

                    if (gameData != null)
                    {
                        gameData.IdleHours += secondsRunning;
                        gameData.LastIdle = DateTime.Now;
                        _gameDataManager.SaveData(gameDataList);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }
    }
}