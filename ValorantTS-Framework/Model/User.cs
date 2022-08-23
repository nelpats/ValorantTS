using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValorantTS.Model
{
    internal class User
    {
        public Point Resolution { get; set; }
        public Point DefaultResolution { get; set; }
        public string Userid { get; set; }
        public User(string userid, Point resolution, Point defaultResolution)
        {
            this.Userid = userid;
            this.Resolution = resolution;
            this.DefaultResolution = defaultResolution;
        }
    }
}
