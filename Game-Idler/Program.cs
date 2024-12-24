using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Game_Idler;
using Steamworks;

static class Program
{
    static void Main(string[] args)
    {
        try 
        {
            long AppID = long.Parse(args[0]);
            string Name = args[1];
            Environment.SetEnvironmentVariable("SteamAppId", AppID.ToString());

            if (!SteamAPI.Init())
            {
                return;
            }

            if (args[2] == "true")
            {
                Application.Run(new IdleForm(AppID, Name, true));
            }
            else if (args[2] == "false")
            {
                Application.Run(new IdleForm(AppID, Name, false));
            }
        }
        catch 
        {
            return;
        }
    }
}