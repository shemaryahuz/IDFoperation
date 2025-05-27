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
        public AMAN amanUnit;
        public StrikeUnit strikeUnit;
        public IDF(Hamas hamas)
        {
            this.EstablishDate = new DateTime(1948, 5, 26).Date;
            this.CurrentCommander = "Eyal Zamir";
            this.amanUnit = new AMAN(hamas);
            this.strikeUnit = new StrikeUnit();
        }
    }
}
