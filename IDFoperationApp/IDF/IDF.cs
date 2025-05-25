using System;
using System.Collections.Generic;
using System.Linq;
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
        public bool ConfirmAttack(IntelMessage intelMessage, IStrikeOption strikeOption)
        {
            if (intelMessage.IntelTerrorist.IsAlive && strikeOption.Capacity < 0)
            {
                return true;
            }
            return false;
        }
        public void Attack(Hamas hamas, IntelTerrorist intelTerrorist, IStrikeOption strikeOption)
        {
            foreach (Terrorist terrorist in hamas.Terrorists)
            {
                if (terrorist.Name == intelTerrorist.Name)
                {
                    terrorist.IsAlive = false;
                    intelTerrorist.IsAlive = false;
                }
                strikeOption.Capacity--;
            }
        }
    }
}
