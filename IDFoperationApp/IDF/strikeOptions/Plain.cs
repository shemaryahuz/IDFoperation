using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class Plain : IStrikeOption
    {
        public string UniqueName { get; set; }
        public int Capacity { get; set; }
        public string[] BombsType { get; set; }
        public string[] TypeOfTarget { get; set; }
        public Plain(string uniqeName)
        {
            this.UniqueName = uniqeName;
            this.Capacity = 8;
            this.BombsType = new string[] { "0.5 ton", "1 ton" };
            this.TypeOfTarget = new string[] { "Buildings" };
        }
        public void Supply()
        {
            this.Capacity += 4;
        }
    }
}
