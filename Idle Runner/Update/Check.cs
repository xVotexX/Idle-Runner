using Octokit;
using Microsoft.Toolkit.Uwp.Notifications;

namespace Idle_Runner.Update
{
    public static class Check
    {
        private const string currentVersion = "1.1.0";
        private const string RepoOwner = "xVotexX";
        private const string RepoName = "Idle-Runner";

        public static async Task CheckForUpdatesAsync(System.Windows.Forms.Label updateLabel)
        {
            try
            {
                var client = new GitHubClient(new Octokit.ProductHeaderValue("IdleRunner"));
                var latestRelease = await client.Repository.Release.GetLatest(RepoOwner, RepoName);

                if (latestRelease.TagName != currentVersion)
                {
                    updateLabel.Text = $"Update Available! Latest Release: v{latestRelease.TagName}";
                    updateLabel.Visible = true;

                    ShowUpdateNotification(currentVersion, latestRelease.TagName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking for updates:\n{ex.Message}", "Update Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ShowUpdateNotification(string currentVersion, string newVersion)
        {
            new ToastContentBuilder()
              .AddText("New version is available!")
              .AddText($"Current: v{currentVersion} - Latest: v{newVersion}")
              .AddText("Click to visit the release page for details!")
              .Show();

            ToastNotificationManagerCompat.OnActivated += toastArgs =>
            {
                string releasePageUrl = $"https://github.com/{RepoOwner}/{RepoName}/releases/latest";
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = releasePageUrl,
                    UseShellExecute = true
                });
            };
        }
    }
}