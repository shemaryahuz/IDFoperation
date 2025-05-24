using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class IntelligencMessage
    {
        public string TerroristName;
        public string Location;
        public DateTime Time;
        public IntelligencMessage(string terroristName, string location, DateTime time)
        {
            this.TerroristName = terroristName;
            this.Location = location;
            this.Time = time;
        }
    }
}
