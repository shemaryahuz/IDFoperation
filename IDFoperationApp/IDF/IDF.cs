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
        public IntelMessage ChooseTarget()
        {
            IntelMessage messageOfTarget = this.amanUnit.Messages[this.amanUnit.Messages.Count - 1];
            foreach (IntelMessage intelMessage in this.amanUnit.Messages)
            {
                if (intelMessage.IntelTerrorist.Rank > messageOfTarget.IntelTerrorist.Rank)
                {
                    messageOfTarget = intelMessage;
                }
            }
            return messageOfTarget;
        }
        public IStrikeOption ChooseStrikeOption(IntelMessage intelMessage)
        {
            switch (intelMessage.Location)
            {
                case "Home":                       
                    return this.strikeUnit.StrikeOptionsData["Plains"][0];
                case "Car":
                    return this.strikeUnit.StrikeOptionsData["Artillery"][0];
                default:
                    return this.strikeUnit.StrikeOptionsData["Drones"][0];
            }
        }
        public bool ConfirmAttack(IntelTerrorist intelTerrorist, IStrikeOption strikeOption)
        {
            if (intelTerrorist.IsAlive && strikeOption.Capacity < 0)
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
