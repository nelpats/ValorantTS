using System;
using Console = Colorful.Console;
using ValorantTS.Modules;
using ValorantTS.Utils;
using System.Threading;

namespace ValorantTS
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "ValorantTS | github.com/nelpats";
            Logger logger = new Logger();
            GameListener valHooker = new GameListener();


            logger.Say("Setting up VALORANT config...");
            ConfigUtils.Init();
            ConfigUtils.SetValorantConfig();

            // initializing hook
            valHooker.Init();

            while (!valHooker.GameFound) { Thread.Sleep(50); }
            Thread.Sleep(1500);
            Console.Clear();

            valHooker.Stop();
            logger.Say("Press enter once the game is fully started");
            Console.ReadLine();

            Thread.Sleep(1500);
            logger.Say("Stretching screen...");
            Native.SetStretchedMode(valHooker.hwnd);
            logger.SayOk("Done !");

            ConfigUtils.ChangeResolution(true);
            valHooker.Start();

            Thread.Sleep(500);

            logger.SayOk("Press enter when you're finished playing");
            Console.ReadLine();

            valHooker.Stop();
            ConfigUtils.ChangeResolution(false);
            Environment.Exit(0);


        }
    }
}