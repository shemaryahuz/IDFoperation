using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class IDF: Organization
    {
        private static IDF _Instance;
        private IDF(Hamas hamas)
        {
            EstablishDate = new DateTime(1948, 5, 26).Date;
            CurrentCommander = "Eyal Zamir";
            IntelUnit = IntelUnit.GetInstance(hamas);
            StrikeUnit = StrikeUnit.GetInstance();
        }
        public static IDF GetInstance(Hamas hamas)
        {
            if (_Instance is null)
            {
                _Instance = new IDF(hamas);
            }
            return _Instance;
        }
        public IntelUnit IntelUnit { get; set; }
        public StrikeUnit StrikeUnit { get; set; }
    }
}
