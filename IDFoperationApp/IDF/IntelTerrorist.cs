using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class IntelTerrorist: Terrorist
    {
        public int Reports;
        public int Score;
        public IntelTerrorist(Terrorist terrorist):base(terrorist.Name, terrorist.Rank, terrorist.Weapons)
        {
            this.Name = terrorist.Name;
            this.Rank = terrorist.Rank;
            this.IsAlive = terrorist.IsAlive;
            this.Weapons = terrorist.Weapons;
        }
    }
}
