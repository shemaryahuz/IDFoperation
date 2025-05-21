using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class Hamas: IOrganization
    {
        public DateTime EstablishDate { get; set; }
        public string CurrentCommander { get; set; }
        public List<Terrorist> Terrorists = new List<Terrorist>();
        public void AddTerrorist(Terrorist terrorist)
        {
            this.Terrorists.Add(terrorist);
        }
        public void RemoveTerrorist(Terrorist terrorist)
        {
            this.Terrorists.Remove(terrorist);
        }

    }
}
