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
        public Dictionary<string, IntelTerrorist> IntelTerrorists { get; set; } = new Dictionary<string, IntelTerrorist>();
        public List<IntelMessage> IntelMessages { get; set; } = new List<IntelMessage>();
    }
}
