using Microsoft.VisualBasic;
using System;
using System.Drawing;
using Console = Colorful.Console;

namespace ValorantTS.Utils
{
    internal class Logger
    {
        private void Prefix()
        {
            Console.Write("[", Color.Gray);
            Console.Write(DateTime.Now.ToString("HH:mm:ss"), Color.White);
            Console.Write("] ", Color.Gray);

        }
        public void Say(string message)
        {
            Prefix();
            Console.WriteLine(message, Color.Gray);
        }

        public void SayOk(string message)
        {
            Console.Write("OK ", Color.Green);
            Console.WriteLine(message, Color.Gray);
        }

        public void SayError(string message)
        {
            Console.Write("ERROR ", Color.IndianRed);
            Console.WriteLine(message, Color.Gray);
        }

        public string Ask(string query)
        {
            Console.Write(query, Color.White);
            Console.Write(" > ", Color.Gray);
            return Console.ReadLine();
        }

      

    }
}
