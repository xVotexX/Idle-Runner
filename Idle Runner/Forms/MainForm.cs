using Idle_Runner.Helper;
using Idle_Runner.Update;
using System.Diagnostics;

namespace Idle_Runner
{
    public partial class MainForm : Form
    {
        private readonly GetGames gameHelper;
        private readonly GameDataManager gameDataManager;
        private readonly IdleProcessMonitor monitor;

        public MainForm()
        {
            InitializeComponent();
            gameHelper = new GetGames();
            gameDataManager = new GameDataManager();
            monitor = new IdleProcessMonitor();
        }

        // --- Initialization methods ---

        public async void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                var installedGames = gameHelper.GetInstalledGames(statusLabel);
                gameDataManager.UpdateGameData(installedGames);

                gameListBox.DataSource = installedGames;
                gameListBox.DisplayMember = "Name";
                gameListBox.ValueMember = "AppId";

                UpdateStatus("Ready!", Color.Green);
            }
            catch (Exception ex)
            {
                HandleError(ex, "Loading games during initialization");
                UpdateStatus("Failed to load games.", Color.Red);
            }

            await Check.CheckForUpdatesAsync(updateLabel);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ProcessKiller.KillAllIdlingProcesses(statusLabel, monitor);
            }
            catch (Exception ex)
            {
                HandleError(ex, "Closing application");
            }
        }

        // --- UI interaction methods ---

        private void linkPictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo("https://github.com/xVotexX") { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                HandleError(ex, "Opening link");
            }
        }

        private void linkPictureBox_MouseEnter(object sender, EventArgs e) => linkPictureBox.Cursor = Cursors.Hand;
        private void linkPictureBox_MouseLeave(object sender, EventArgs e) => linkPictureBox.Cursor = Cursors.Default;

        public void gameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedGame = (Game)gameListBox.SelectedItem;
            int appId = selectedGame.AppId;

            try
            {
                gameHeader.Load($"https://cdn.akamai.steamstatic.com/steam/apps/{appId}/header_292x136.jpg");
            }
            catch
            {
                gameHeader.Load($"https://i.imgur.com/EDpD73y.jpeg");
            }

            try
            {
                var gameDataList = gameDataManager.LoadData();
                var selectedGameData = gameDataList.FirstOrDefault(g => g.AppId == appId);

                if (selectedGameData != null)
                {
                    lastIdleLabel.Text = selectedGameData.LastIdle?.ToString("g") ?? "Never";
                    idleHoursLabel.Text = $"{Math.Round(selectedGameData.IdleHours / 3600, 1)} Hours";
                }
                else
                {
                    lastIdleLabel.Text = "Never";
                    idleHoursLabel.Text = "0 Hours";
                }
            }
            catch (Exception ex)
            {
                HandleError(ex, "Loading game data");
                lastIdleLabel.Text = "Never";
                idleHoursLabel.Text = "0 Hours";
            }
        }

        // --- Core functionality ---

        private async void startIdleButton_Click(object sender, EventArgs e)
        {
            gameListBox.Enabled = false;
            startIdleButton.Enabled = false;

            string GameIdlerPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Game-Idler.exe");
            string SteamApiPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "steam_api64.dll");

            if (!File.Exists(GameIdlerPath))
            {
                MessageBox.Show("Game-Idler.exe could not be found.\nEnsure it is in the same directory!", "Missing File!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gameListBox.Enabled = true;
                startIdleButton.Enabled = true;
                return;
            }
            
            if (!File.Exists(SteamApiPath))
            {
                MessageBox.Show("steam_api64.dll could not be found.\nEnsure it is in the same directory!", "Missing File!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gameListBox.Enabled = true;
                startIdleButton.Enabled = true;
                return;
            }

            var foundProcesses = new List<string>();
            var tasks = new List<Task>();
            int count = 0;

            foreach (var selectedItem in gameListBox.SelectedItems)
            {
                if (selectedItem is not Game selectedGame)
                    continue;

                UpdateStatus($"Starting {selectedGame.Name}...", Color.Orange);

                var runningProcesses = monitor.GetRunningProcesses();
                if (runningProcesses.ContainsKey(selectedGame.AppId))
                {
                    count++;
                    foundProcesses.Add(selectedGame.Name);
                }
                else
                {
                    tasks.Add(monitor.MonitorProcessAsync(selectedGame, hideIdleCheck));
                }

                await Task.Delay(100); // Allow UI to update
            }

            gameListBox.Enabled = true;
            startIdleButton.Enabled = true;

            UpdateStatus("Finished!", Color.Green);

            if (count > 0)
            {
                MessageBox.Show($"{count} games are already idling:\n" + string.Join("\n", foundProcesses), "Idler Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            await Task.WhenAll(tasks);
        }

        private void checkIdleButton_Click(object sender, EventArgs e)
        {
            var runningProcesses = monitor.GetRunningProcesses();

            if (runningProcesses.Count > 0)
            {
                var foundProcesses = runningProcesses.Select(p => $"{p.Value.Name} - {p.Key}").ToList();

                MessageBox.Show(
                    $"{runningProcesses.Count} games are idling:\n" + string.Join("\n", foundProcesses),
                    "Idler Check",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                UpdateStatus("No games are currently idling.", Color.Yellow);
            }
        }

        public void killIdleButton_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessKiller.KillAllIdlingProcesses(statusLabel, monitor);
            }
            catch (Exception ex)
            {
                HandleError(ex, "Killing idle processes");
            }
        }

        private void addToGroupButton_Click(object sender, EventArgs e)
        {
            UpdateStatus("Soon™", Color.Yellow);
        }

        // --- Helper methods ---

        private void HandleError(Exception ex, string context)
        {
            MessageBox.Show($"An error occurred in {context}:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void UpdateStatus(string message, Color color)
        {
            statusLabel.Text = message;
            statusLabel.ForeColor = color;
        }
    }
}