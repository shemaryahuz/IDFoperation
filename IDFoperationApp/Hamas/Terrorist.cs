using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class Terrorist
    {
        public string Name;
        public int Rank;
        public bool IsAlive;
        public List<string> Weapons = new List<string>();
        public Terrorist(string name, int rank, List<string> weapons)
        {
            this.Name = name;
            this.Rank = rank;
            this.IsAlive = true;
            this.Weapons = weapons;
        }
    }
}
