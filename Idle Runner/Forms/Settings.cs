using Idle_Runner.Discord;
using Idle_Runner.Helper;
using System.Globalization;

namespace Idle_Runner.Forms
{
    public partial class Settings : Form
    {
        public MainForm ParentForm { get; set; }
        private readonly ConfigManager config;
        private readonly GameDataManager gameDataManager;
        private readonly RPC discordRPCManager;

        public Settings(ConfigManager config, RPC rpcInstance)
        {
            InitializeComponent();
            this.config = config;
            gameDataManager = new GameDataManager();
            discordRPCManager = rpcInstance ?? throw new ArgumentNullException(nameof(rpcInstance));

            rpcCheck.Checked = config.RpcCheck;
            hideIdleCheck.Checked = config.HideIdleCheck;
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            ParentForm.CloseSettingsMenu();
        }

        private async void rpcCheck_CheckedChanged(object sender, EventArgs e)
        {
            rpcCheck.Enabled = false;
            try
            {
                await Task.Run(() =>
                {
                    config.UpdateRpcCheck(rpcCheck.Checked);
                    discordRPCManager.EnableRPC(rpcCheck.Checked);
                });
            }
            finally
            {
                rpcCheck.Enabled = true;
            }
        }

        private void hideIdleCheck_CheckedChanged(object sender, EventArgs e)
        {
            config.UpdateHideIdleCheck(hideIdleCheck.Checked);
        }

        private void gameListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedGame = (Game)gameListComboBox.SelectedItem;
            int appId = selectedGame.AppId;

            var gameDataList = gameDataManager.LoadData();
            var selectedGameData = gameDataList.FirstOrDefault(g => g.AppId == appId);

            if (selectedGameData != null)
            {
                idletimeTextBox.Text = $"{Math.Round(selectedGameData.IdleHours / 3600, 1)}";
            }
        }

        private void applyTimeButton_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedGame = (Game)gameListComboBox.SelectedItem;

                var gameDataList = gameDataManager.LoadData();
                var gameData = gameDataList.FirstOrDefault(g => g.AppId == selectedGame.AppId);

                if (gameData != null)
                {
                    if (double.TryParse(idletimeTextBox.Text, out double hours))
                    {
                        double seconds = hours * 3600;

                        gameData.IdleHours = seconds;
                        gameDataManager.SaveData(gameDataList);

                        System.Media.SystemSounds.Asterisk.Play();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void playtimeBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar.ToString() == separator);
        }

        private void resetTimeButton_Click(object sender, EventArgs e)
        {
            try
            {
                var confirmResult = MessageBox.Show("Are you sure you want to reset idletimes for all games?\n" 
                    + "This action cannot be undone.", 
                    "Confirm Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    var gameDataList = gameDataManager.LoadData();
                    foreach (var gameData in gameDataList)
                    {
                        gameData.LastIdle = null;
                        gameData.IdleHours = 0;
                    }

                    gameDataManager.SaveData(gameDataList);
                    MessageBox.Show("Idle times for all games have been reset!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while resetting idle times:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteDataButton_Click(object sender, EventArgs e)
        {
            try
            {
                var confirmResult = MessageBox.Show(
                    "This will delete all registered games and Idletimes.\n"
                    + "This action cannot be undone.\n" 
                    + "The application will restart afterwards.", 
                    "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    gameDataManager.SaveData(new List<GameData>());
                    MessageBox.Show("All game data has been deleted. The application will now restart.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Application.Restart();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting game data:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}