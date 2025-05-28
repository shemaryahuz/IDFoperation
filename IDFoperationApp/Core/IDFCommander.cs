
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal static class IDFCommander
    {
        public static IntelMessage ChooseTarget(IDF idf)
        {
            IntelMessage messageOfTarget = idf.IntelUnit.Messages[idf.IntelUnit.Messages.Count - 1];
            foreach (IntelMessage intelMessage in idf.IntelUnit.Messages)
            {
                if (intelMessage.IntelTerrorist.Rank > messageOfTarget.IntelTerrorist.Rank && intelMessage.IntelTerrorist.IsAlive)
                {
                    messageOfTarget = intelMessage;
                }
            }
            return messageOfTarget;
        }
        public static IStrikeOption ChooseStrikeOption(IDF idf, IntelMessage intelMessage)
        {
            switch (intelMessage.Location)
            {
                case "Home":
                    return idf.StrikeUnit.StrikeOptionsData["Plains"][0];
                case "Car":
                    return idf.StrikeUnit.StrikeOptionsData["Artilleries"][0];
                default:
                    return idf.StrikeUnit.StrikeOptionsData["Drones"][0];
            }
        }
        public static bool ConfirmAttack(IntelTerrorist intelTerrorist, IStrikeOption strikeOption)
        {
            if (intelTerrorist.IsAlive && strikeOption.Capacity > 0)
            {
                return true;
            }
            return false;
        }
        public static void Attack(Hamas hamas, IntelTerrorist intelTerrorist, IStrikeOption strikeOption)
        {
            foreach (Terrorist terrorist in hamas.Terrorists)
            {
                if (terrorist.Name == intelTerrorist.Name)
                {
                    terrorist.IsAlive = false;
                    intelTerrorist.IsAlive = false;
                }
            }
            strikeOption.Capacity--;
        }
        public static void AttackByDangerous(IDF idf, Hamas hamas)
        {
            IntelMessage intelMessage = IDFCommander.ChooseTarget(idf);
            IStrikeOption strikeOption = IDFCommander.ChooseStrikeOption(idf, intelMessage);
            bool confirmed = IDFCommander.ConfirmAttack(intelMessage.IntelTerrorist, strikeOption);
            if (confirmed)
            {
                IDFCommander.Attack(hamas, intelMessage.IntelTerrorist, strikeOption);
                Console.WriteLine($"The Attack was successful! {intelMessage.IntelTerrorist.Name} is dead!");
                Console.WriteLine($"The Capacity of the {strikeOption.UniqueName} is {strikeOption.Capacity}.\n");
            }
            else if (!intelMessage.IntelTerrorist.IsAlive)
            {
                Console.WriteLine($"{intelMessage.IntelTerrorist.Name} is already dead.\n");
            }
            else
            {
                Console.WriteLine($"There are not enough bombs for the {strikeOption.UniqueName}, Please Supply.\n");
            }
        }
    }
}
