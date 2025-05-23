using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class AMAN
    {
        public Dictionary<IntelTerrorist, List<IntelligencMessage>> Messages = new Dictionary<IntelTerrorist, List<IntelligencMessage>>();
        public Dictionary<IntelTerrorist, int[]> IntelTerrorists = new Dictionary<IntelTerrorist, int[]>();
        public AMAN()
        {

        }
        public void AddIntelTerrorist(Terrorist terrorist)
        {
            IntelTerrorist intelTerrorist = new IntelTerrorist(terrorist);
            this.IntelTerrorists[intelTerrorist] = new int[] {intelTerrorist.Reports, intelTerrorist.Score};
        }
        public void AddMessage(IntelTerrorist terrorist, string location, DateTime time)
        {
            IntelligencMessage message = new IntelligencMessage(terrorist, location, time);
            this.Messages[terrorist].Add(message);
            terrorist.Reports++;
        }
    }
}
