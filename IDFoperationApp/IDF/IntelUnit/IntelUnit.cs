using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    // This class represents the Intel Unit of the IDF, That stores Data about terrorists and intel messages
    internal class IntelUnit
    {
        private static IntelUnit _Instance;
        // Constructor to add all the terrorists of hamas to the intel Unit as Intel Terrorists
        private IntelUnit()
        {
            Hamas hamas = Hamas.GetInstance();
            foreach (Terrorist terrorist in hamas.Terrorists)
            {
                IntelTerrorist intelTerrorist = new IntelTerrorist(terrorist);
                IntelTerrorists.Add(intelTerrorist.Name, intelTerrorist);
            }
        }
        // This method returns the intelUnit instance (using singleton pattern)
        public static IntelUnit GetInstance()
        {
            if (_Instance is null)
            {
                _Instance = new IntelUnit();
            }
            return _Instance;
        }
        // A dictionary to store data about terrorist. keys are the terorrits name and values are the intel terrorist object
        public Dictionary<string, IntelTerrorist> IntelTerrorists { get; set; } = new Dictionary<string, IntelTerrorist>();
        // A list to store the intel messages
        public List<IntelMessage> IntelMessages { get; set; } = new List<IntelMessage>();
        // This metthod is adding an Intel terrorist by name using the hamas instance
        public void AddIntelTerrorist(string terroristName)
        {
            Hamas hamas = Hamas.GetInstance();
            foreach (Terrorist terrorist in hamas.Terrorists)
            {
                if(terrorist.Name == terroristName)
                {
                    IntelTerrorist intelTerrorist = new IntelTerrorist(terrorist);
                    IntelTerrorists.Add(terroristName, intelTerrorist);
                    break;
                }
            }
            
        }
    }
}
