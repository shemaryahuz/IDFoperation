using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class Hamas: Organization
    {
        private static Hamas _Instance;
        private Hamas()
        {
            this.EstablishDate = new DateTime(1987, 12, 10).Date;
            this.CurrentCommander = "Mohammed Sinwar";
            this.AddTerrorist("Mohammed Sinwar", 5, new List<string>() { "Rifle", "Gun" });
            this.AddTerrorist("Abu Ali", 3, new List<string>() { "Gun", "Gun" });
            this.AddTerrorist("Said Hamdi", 2, new List<string>() { "Gun", "Knif" });
        }
        public static Hamas GetInstans()
        {
            if (_Instance is null)
            {
                _Instance = new Hamas();
            }
            return _Instance;
        }
        public List<Terrorist> Terrorists = new List<Terrorist>();

        public void AddTerrorist(string name, int rank, List<string> wepon)
        {
            Terrorist terrorist = new Terrorist(name, rank, wepon);
            Terrorists.Add(terrorist);
        }
    }
}
