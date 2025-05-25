using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class Artillery: IStrikeOption
    {
        public string UniqueName { get; set; }
        public int Capacity { get; set; }
        public string[] BombsType { get; set; }
        public string[] TypeOfTarget { get; set; }
        public Artillery(string uniqeName)
        {
            this.UniqueName = uniqeName;
            this.Capacity = 20;
            this.BombsType = new string[] { "Explosive shells" };
            this.TypeOfTarget = new string[] { "Open areas" };
        }
        public void Supply()
        {
            this.Capacity += 40;
        }
    }
}
