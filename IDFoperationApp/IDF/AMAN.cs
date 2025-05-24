using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class AMAN
    {
        public Dictionary<string, int[]> IntelTerrorists = new Dictionary<string, int[]>();
        //public List<IntelligencMessage> Messages = new List<IntelligencMessage>();
        public AMAN(Hamas hamas)
        {
            foreach (Terrorist terrorist in hamas.Terrorists)
            {
                this.AddIntelTerrorist(terrorist);
            }
            //IntelligencMessage message1 = new IntelligencMessage("Mohammad Sinwar", "Home", new DateTime(2025, 4, 20, 12, 20, 0));
            //IntelligencMessage message2 = new IntelligencMessage("Abu Ali", "Car", new DateTime(2025, 5, 10, 11, 8, 0));
            //IntelligencMessage message3 = new IntelligencMessage("Said Hamdi", "Home", new DateTime(2025, 5, 24, 13, 30, 50));
        }
        public void AddIntelTerrorist(Terrorist terrorist)
        {
            IntelTerrorist intelTerrorist = new IntelTerrorist(terrorist);
            this.IntelTerrorists[intelTerrorist.Name] = new int[] {intelTerrorist.Reports, intelTerrorist.Score};
        }
    }
}
