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
        
        private IntelUnit()
        {
        }
        public static IntelUnit GetInstance()
        {
            if (_Instance is null)
            {
                _Instance = new IntelUnit();
            }
            return _Instance;
        }
        public List<IntelTerrorist> IntelTerrorists { get; set; } = new List<IntelTerrorist>();
        public List<IntelMessage> Messages { get; set; } = new List<IntelMessage>();
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
