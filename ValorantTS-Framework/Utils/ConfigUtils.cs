using Newtonsoft.Json;
using ValorantTS.Model;
using IniParser;
using IniParser.Model;
using System;
using System.IO;
using System.Drawing;

namespace ValorantTS.Utils
{
    internal class ConfigUtils
    {
        private const string PATH_TO_QRES = "QRes\\QRes.exe";
        static string PATH_TO_CONFIG = "user.json";

        static readonly User defaultUser = new User("N/A", new Point(1280, 960), new Point(1920, 1080));

        static readonly Logger logger = new Logger();
        public static User User 
        { 
            get
            {
                var content = File.ReadAllText(PATH_TO_CONFIG);
                return JsonConvert.DeserializeObject<User>(content);
            } 
        }


        public static void Init()
        {
            if (!File.Exists(PATH_TO_CONFIG))
            {
                ResetFile();
            }
        }

        public static void ChangeResolution(bool mode)
        {
            int x, y = 0;

            if (mode)
            {
                x = User.Resolution.X;
                y = User.Resolution.Y;
            } 
            else
            {
                x = User.DefaultResolution.X;
                y = User.DefaultResolution.Y;
            }

            if (!File.Exists(PATH_TO_QRES))
            {
                logger.SayError("QRes not found");
                Console.ReadKey();
                Environment.Exit(1);
            }

            Native.Shell($"{PATH_TO_QRES} /x {x} /y {y}");

        }



        public static void SetValorantConfig()
        {
            IniData data = null;
            var path = $@"C:\Users\{Environment.UserName}\AppData\Local\VALORANT\Saved\Config\{User.Userid}\Windows\GameUserSettings.ini";

            var parser = new FileIniDataParser();

            try 
            {
                data = parser.ReadFile(path);
            } 
            catch
            {
                logger.SayError("Invalid userid !");
                Console.ReadKey();
                Environment.Exit(1);
            }
            

            logger.SayOk("Config found");

            var section = data["/Script/ShooterGame.ShooterGameUserSettings"];

            if (section["bShouldLetterbox"] == "True") section["bShouldLetterbox"] = "False";

            section["DesiredScreenWidth"] = User.DefaultResolution.X.ToString();
            section["DesiredScreenHeight"] = User.DefaultResolution.Y.ToString();

            section["ResolutionSizeX"] = User.DefaultResolution.X.ToString();
            section["ResolutionSizeY"] = User.DefaultResolution.Y.ToString();

            section["LastUserConfirmedResolutionSizeX"] = User.DefaultResolution.X.ToString();
            section["LastUserConfirmedResolutionSizeY"] = User.DefaultResolution.Y.ToString();

            section["LastConfirmedFullscreenMode"] = "0";
            section["PreferredFullscreenMode"] = "0";

            File.SetAttributes(path, FileAttributes.Normal);
            parser.WriteFile(path, data);
            logger.SayOk("Config edited");
        }

        private static void ResetFile()
        {
            logger.SayError("Resetting config file !");
            File.WriteAllText(PATH_TO_CONFIG, JsonConvert.SerializeObject(defaultUser, Formatting.Indented));
            logger.SayOk("Config file reset !");
        }
    }
}
