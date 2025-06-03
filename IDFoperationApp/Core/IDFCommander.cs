
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal static class IDFCommander
    {
        public static IntelMessage ChooseTarget()
        {
            IntelMessage messageOfTarget = IDF.GetInstance().IntelUnit.Messages[IDF.GetInstance().IntelUnit.Messages.Count - 1];
            foreach (IntelMessage intelMessage in IDF.GetInstance().IntelUnit.Messages)
            {
                if (intelMessage.IntelTerrorist.Rank > messageOfTarget.IntelTerrorist.Rank && intelMessage.IntelTerrorist.IsAlive)
                {
                    messageOfTarget = intelMessage;
                }
            }
            return messageOfTarget;
        }
        public static IStrikeOption ChooseStrikeOption(IntelMessage intelMessage)
        {
            switch (intelMessage.Location)
            {
                case "Home":
                    return IDF.GetInstance().StrikeUnit.StrikeOptionsData["Plains"][0];
                case "Car":
                    return IDF.GetInstance().StrikeUnit.StrikeOptionsData["Artilleries"][0];
                default:
                    return IDF.GetInstance().StrikeUnit.StrikeOptionsData["Drones"][0];
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
        public static void Attack(IntelTerrorist intelTerrorist, IStrikeOption strikeOption)
        {
            foreach (Terrorist terrorist in Hamas.GetInstance().Terrorists)
            {
                if (terrorist.Name == intelTerrorist.Name)
                {
                    terrorist.IsAlive = false;
                    intelTerrorist.IsAlive = false;
                }
            }
            strikeOption.Capacity--;
        }
        public static void AttackByDangerous()
        {
            IntelMessage intelMessage = IDFCommander.ChooseTarget();
            IStrikeOption strikeOption = IDFCommander.ChooseStrikeOption(intelMessage);
            bool confirmed = IDFCommander.ConfirmAttack(intelMessage.IntelTerrorist, strikeOption);
            if (confirmed)
            {
                IDFCommander.Attack(intelMessage.IntelTerrorist, strikeOption);
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
