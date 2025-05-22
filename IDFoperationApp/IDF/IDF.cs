using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class IDF: Organization
    {
        public IDF()
        {
            EstablishDate = new DateTime(1948, 5, 26).Date;
            CurrentCommander = "Eyal Zamir";
        }
        public AMAN amanUnit = new AMAN();
        // to add StrikeUnit that store the idf strike options
    }
}
