using System.Text.Json;

namespace Idle_Runner.Helper
{
    public class ConfigManager
    {
        private static readonly string ConfigDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Idle Runner");
        private static readonly string ConfigFilePath = Path.Combine(ConfigDirectory, "config.json");

        public bool RpcCheck { get; set; } = true;
        public bool HideIdleCheck { get; set; } = false;

        public static ConfigManager Load()
        {
            try
            {
                if (!Directory.Exists(ConfigDirectory))
                {
                    Directory.CreateDirectory(ConfigDirectory);
                }

                if (File.Exists(ConfigFilePath))
                {
                    string json = File.ReadAllText(ConfigFilePath);
                    return JsonSerializer.Deserialize<ConfigManager>(json) ?? new ConfigManager();
                }
                else
                {
                    var config = new ConfigManager();
                    config.Save();
                    return config;
                }
            }
            catch (Exception)
            {
                return new ConfigManager();
            }
        }

        public void Save()
        {
            try
            {
                string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(ConfigFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving Config:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateRpcCheck(bool value)
        {
            RpcCheck = value;
            Save();
        }

        public void UpdateHideIdleCheck(bool value)
        {
            HideIdleCheck = value;
            Save();
        }
    }
}
