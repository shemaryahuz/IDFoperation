using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class Hamas: Organization
    {
        public static List<Terrorist> Terrorists = new List<Terrorist>();
        public Hamas()
        {
            EstablishDate = new DateTime(1987, 12, 10).Date;
            CurrentCommander = "Mohammed Sinwar";
        }
        public static void AddTerrorist(Terrorist terrorist)
        {
            Terrorists.Add(terrorist);
        }
        public static void RemoveTerrorist(Terrorist terrorist)
        {
            Terrorists.Remove(terrorist);
        }

    }
}
