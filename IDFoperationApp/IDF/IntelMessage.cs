using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class IntelMessage
    {
        public IntelTerrorist IntelTerrorist;
        public string Location;
        public DateTime Time;
        public IntelMessage(IntelTerrorist intelTerrorist, string location, DateTime time)
        {
            this.IntelTerrorist = intelTerrorist;
            this.Location = location;
            this.Time = time;
        }
    }
}
