using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class Hamas: Organization
    {
        public List<Terrorist> Terrorists = new List<Terrorist>();
        public Hamas()
        {
            this.EstablishDate = new DateTime(1987, 12, 10).Date;
            Terrorist mohammadSinwar = new Terrorist("Mohammed Sinwar", 5, new List<string>() { "Rifle", "Gun" });
            this.CurrentCommander = mohammadSinwar.Name;
            this.AddTerrorist(mohammadSinwar);
            Terrorist ali = new Terrorist("Ali", 3, new List<string>() { "Gun", "Gun" });
            Terrorist said = new Terrorist("Said", 2, new List<string>() { "Gun", "Knif" });
            this.AddTerrorist(ali);
            this.AddTerrorist(said);
        }
        public void AddTerrorist(Terrorist terrorist)
        {
            this.Terrorists.Add(terrorist);
        }
    }
}
