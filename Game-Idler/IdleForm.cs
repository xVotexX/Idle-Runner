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
                string iconPath = Path.Combine(steamPath, "appcache", "librarycache", $"{AppID}_icon.jpg");

                if (File.Exists(iconPath))
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

        private void IdleForm_Load(object sender, EventArgs e)
        {

        }
    }
}