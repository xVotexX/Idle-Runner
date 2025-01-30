using DiscordRPC;
using Idle_Runner.Helper;
using System.Diagnostics;

namespace Idle_Runner.Discord
{
    public class RPC : IDisposable
    {
        private readonly object _presenceLock = new();
        private readonly object _operationLock = new();
        private ConfigManager config;
        private DiscordRpcClient client;
        private IdleProcessMonitor monitor;
        private bool isTimestampSet;
        private bool isEnabled;
        private bool _disposed;

        public RPC(ConfigManager config)
        {
            this.config = config;

            if (config.RpcCheck)
            {
                InitializeClient();
            }
        }

        public void SetMonitor(IdleProcessMonitor monitor)
        {
            this.monitor = monitor;
        }

        private void InitializeClient()
        {
            lock (_operationLock)
            {
                try
                {
                    client = new DiscordRpcClient("1332421996440715348");
                    if (client.Initialize())
                    {
                        SetDefaultPresence();
                        isEnabled = true;
                    }
                    else
                    {
                        client.Dispose();
                        client = null;
                        isEnabled = false;
                    }
                }
                catch (Exception ex)
                {
                    client?.Dispose();
                    client = null;
                    isEnabled = false;
                }
            }
        }

        public void SetDefaultPresence()
        {
            client.SetPresence(new RichPresence()
            {
                Details = "No games idling...",
                Buttons = new[]
                {
                    new DiscordRPC.Button() { Label = "View on GitHub", Url = "https://github.com/xVotexX/Idle-Runner" }
                },
            });

            isTimestampSet = false;
        }

        public void UpdatePresence(int newActiveIdlers)
        {
            lock (_presenceLock)
            {
                if (!isEnabled || client == null || !client.IsInitialized) return;

                if (newActiveIdlers == 0)
                {
                    client.UpdateDetails("No games idling...");
                    client.UpdateClearTime();
                    isTimestampSet = false;
                }
                else
                {
                    if (!isTimestampSet)
                    {
                        client.UpdateStartTime();
                        isTimestampSet = true;
                    }

                    client.UpdateDetails($"Idling {newActiveIdlers} game(s)...");
                }
            }
        }

        public void EnableRPC(bool enable)
        {
            lock (_operationLock)
            {
                if (enable == isEnabled) return;
                isEnabled = enable;

                if (enable)
                {
                    if (client == null || !client.IsInitialized)
                    {
                        InitializeClient();
                    }

                    if (client != null && client.IsInitialized)
                    {
                        var runningProcesses = monitor?.GetRunningProcesses() ?? new Dictionary<long, (string, Process)>();
                        UpdatePresence(runningProcesses.Count);
                    }
                }
                else
                {
                    client?.ClearPresence();
                    client?.Dispose();
                    client = null;
                }
            }
        }

        public void Dispose()
        {
            if (_disposed) return;
            client?.ClearPresence();
            client?.Dispose();
            _disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
