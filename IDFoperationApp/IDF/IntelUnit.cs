using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class IntelUnit
    {
        private static IntelUnit _Instance;
        
        private IntelUnit(Hamas hamas)
        {
            foreach (Terrorist terrorist in hamas.Terrorists)
            {
                this.AddIntelTerrorist(terrorist);
            }
            this.AddIntelMessage(this.IntelTerrorists[0], "Home", new DateTime(2025, 4, 20, 9, 30, 5));
            this.AddIntelMessage(this.IntelTerrorists[1], "Car", new DateTime(2025, 5, 10, 11, 20, 7));
            this.AddIntelMessage(this.IntelTerrorists[2], "Home", new DateTime(2025, 5, 25, 2, 25, 3));
        }
        public static IntelUnit GetInstance(Hamas hamas)
        {
            if (_Instance is null)
            {
                _Instance = new IntelUnit(hamas);
            }
            return _Instance;
        }
        public List<IntelTerrorist> IntelTerrorists = new List<IntelTerrorist>();
        public List<IntelMessage> Messages = new List<IntelMessage>();
        public void AddIntelTerrorist(Terrorist terrorist)
        {
            IntelTerrorist intelTerrorist = new IntelTerrorist(terrorist);
            this.IntelTerrorists.Add(intelTerrorist);
        }
        public void AddIntelMessage(IntelTerrorist intelTerrorist, string location, DateTime time)
        {
            IntelMessage message = new IntelMessage(intelTerrorist, location, time);
            message.IntelTerrorist.Reports++;
            this.Messages.Add(message);
        }
    }
}
