using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class AMAN
    {
        public List<IntelligencMessage> Messages = new List<IntelligencMessage>();
        public void CreateMessage(Terrorist terrorist, string location, DateTime time)
        {
            IntelligencMessage message = new IntelligencMessage(terrorist, location, time);
            this.Messages.Add(message);
        }
    }
}
