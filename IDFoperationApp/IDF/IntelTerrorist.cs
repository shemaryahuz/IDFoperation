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
            this.Reports = 0;
            this.Score = 0;
            foreach (string weapon in this.Weapons)
            {
                switch (weapon)
                {
                    case "Rifle":
                        this.Score += this.Rank * 3;
                        break;
                    case "Gun":
                        this.Score += this.Rank * 2;
                        break;
                    case "Knif":
                        this.Score += this.Rank;
                        break;
                }
            }
        }
    }
}
