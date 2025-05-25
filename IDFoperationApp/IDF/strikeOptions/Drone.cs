using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class Drone: IStrikeOption
    {
        public string UniqueName { get; set; }
        public int Capacity { get; set; }
        public string[] BombsType { get; set; }
        public string[] TypeOfTarget { get; set; }
        public Drone(string uniqeName)
        {
            this.UniqueName = uniqeName;
            this.Capacity = 3;
            this.BombsType = new string[] { "Personnel", "Armored vehicles" };
            this.TypeOfTarget = new string[] { "Buildings" , "Open area"};
        }
        public void Supply()
        {
            this.Capacity += 2;
        }
    }
}
