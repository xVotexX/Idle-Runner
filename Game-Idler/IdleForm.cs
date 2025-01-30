namespace Game_Idler
{
    public partial class IdleForm : Form
    {
        public IdleForm(long AppID, string Name, bool Hide)
        {
            InitializeComponent();

            this.Text = $"Idling {Name}!";

            try
            {
                string steamPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Steam");
                string appIdFolder = Path.Combine(steamPath, "appcache", "librarycache", AppID.ToString());
                string oldIconPath = Path.Combine(steamPath, "appcache", "librarycache", $"{AppID}_icon.jpg");
                string iconPath = null;

                if (File.Exists(oldIconPath))
                {
                    iconPath = oldIconPath;
                }
                else
                {
                    if (Directory.Exists(appIdFolder))
                    {
                        foreach (var file in Directory.GetFiles(appIdFolder, "*.jpg"))
                        {
                            string fileName = Path.GetFileNameWithoutExtension(file);
                            if (fileName.Length == 40 && IsHexString(fileName))
                            {
                                iconPath = file;
                                break;
                            }
                        }
                    }
                }

                if (iconPath != null && File.Exists(iconPath))
                {
                    using (Bitmap bitmap = new Bitmap(iconPath))
                    {
                        this.Icon = Icon.FromHandle(bitmap.GetHicon());
                    }
                }
                else
                {
                    this.Icon = SystemIcons.Application;
                }
            }
            catch
            {
                this.Icon = SystemIcons.Warning;
            }

            try
            {
                gameHeader.Load($"https://cdn.akamai.steamstatic.com/steam/apps/{AppID}/header_292x136.jpg");
            }
            catch
            {
                gameHeader.Load($"https://i.imgur.com/EDpD73y.jpeg");
            }

            if (Hide == true)
            {
                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;            
            }
        }

        private bool IsHexString(string str)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str, @"^[0-9a-fA-F]{40}$");
        }

        private void IdleForm_Load(object sender, EventArgs e)
        {

        }
    }
}