using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class IntelligencMessage
    {
        public Terrorist Terrorist;
        public string Location;
        public DateTime Time;
        public IntelligencMessage(Terrorist terrorist, string location, DateTime time)
        {
            this.Terrorist = terrorist;
            this.Location = location;
            this.Time = time;
        }
    }
}
