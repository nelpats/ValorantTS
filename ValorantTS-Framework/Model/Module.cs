using System;
using System.Drawing;
using System.Threading;
using Console = Colorful.Console;

namespace ValorantTS.Modules
{
    abstract class Module
    {
        public abstract string Name { get; }
        protected bool Enabled { get; set; } = false;
        protected bool Running { get; set; } = false;
        protected Thread _thread { get; set; }

        protected int defaultDelay = 25;
        protected Module()
        {
        }

        protected void LogModule(string message)
        {
            Console.Write("[", Color.White);
            Console.Write(this.Name, Color.Violet);
            Console.Write("] ", Color.White);
            Console.WriteLine(message, Color.Gray);
        }

        protected void ThreadFunc()
        {
            while (this.Running)
            {
                Thread.Sleep(this.defaultDelay);
                if (this.Enabled)  { OnCall(); } else { Thread.Sleep(50); }            
                
            }
        }

        public virtual void Init()
        {
            OnInit();

            this.Enabled = true;
            this.Running = true;

            this._thread = new Thread(ThreadFunc);
            this._thread.Start();
      

        }
        protected virtual void OnCall()
        {
        }
        protected abstract void OnInit();

        public virtual void Start() => this.Enabled = true;

        public virtual void Stop() => this.Enabled = false;
    }
}
