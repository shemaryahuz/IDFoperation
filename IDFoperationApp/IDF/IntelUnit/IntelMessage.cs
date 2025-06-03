using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class IntelMessage
    {
        public string TerroristName { get; set; }
        public string Location { get; set; }
        public DateTime Time;
        public IntelMessage(string terroristName, string location, DateTime time)
        {
            this.TerroristName = terroristName;
            this.Location = location;
            this.Time = time;
        }
    }
}
