using System;
using System.Diagnostics;
using ValorantTS.Utils;

namespace ValorantTS.Modules
{
    internal class GameListener : Module
    {
        public override string Name => "Valorant Hooker";

        public IntPtr hwnd = IntPtr.Zero;
        public bool IsGameForeground 
        { 
            get { return hwnd == Native.GetForegroundWindow(); } 
        }

        public bool GameFound = false;
        private bool Logged = false;

        public GameListener() : base()
        {
            base.defaultDelay = 50;
        }
        protected override void OnInit()
        {
            base.LogModule("Waiting for VALORANT...");
        }

        protected override void OnCall()
        {
            try { this.hwnd = Process.GetProcessesByName("VALORANT-Win64-Shipping")[0].MainWindowHandle; } 
            catch { this.GameFound = false; }

            if (this.hwnd != IntPtr.Zero)
            {
                GameFound = true;
            }
            
            if (!Logged && GameFound)
            {
                base.LogModule($"Game found ! ({hwnd})");
                Logged = true;
            }

            // check is the game is foreground to check if the resolution need to be changed.
            if (IsGameForeground && GameFound)
            {
                if (!ConfigUtils.User.Resolution.Equals(Native.GetScreenResolution()))
                {
                    // sets the stretched res
                    ConfigUtils.ChangeResolution(true);
                }
            } 
            else
            {
                if (!ConfigUtils.User.DefaultResolution.Equals(Native.GetScreenResolution()))
                {
                    // sets default res
                    ConfigUtils.ChangeResolution(false);
                }
            }        
        }    
    }
}
