using Idle_Runner.Helper;

public class ProcessKiller
{
    private static readonly List<string> _killedProcesses = new();

    public static void KillAllIdlingProcesses(Label statusLabel, IdleProcessMonitor monitor)
    {
        _killedProcesses.Clear();
        int killCount = 0;

        statusLabel.Text = "Searching for idling processes...";
        statusLabel.ForeColor = Color.Orange;

        Application.DoEvents(); // Update UI

        var runningProcesses = monitor.GetRunningProcesses();

        foreach (var processEntry in runningProcesses)
        {
            try
            {
                var (gameName, process) = processEntry.Value;
                statusLabel.Text = $"Killing {process.MainWindowTitle}...";
                statusLabel.ForeColor = Color.Red;

                Application.DoEvents();

                process.Kill();
                killCount++;
                _killedProcesses.Add($"{gameName} - AppId: {processEntry.Key}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error terminating the process:\n{ex.Message}", "Process Termination Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = $"Failed";
                statusLabel.ForeColor = Color.Red;
            }
        }

        if (killCount > 0)
        {
            statusLabel.Text = $"{killCount} idling processes have been terminated.";
            statusLabel.ForeColor = Color.Green;

            MessageBox.Show($"{killCount} idling processes have been terminated:\n" + string.Join("\n", _killedProcesses), "Process Termination", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            statusLabel.Text = "No idling processes found.";
            statusLabel.ForeColor = Color.Yellow;
        }
    }
}