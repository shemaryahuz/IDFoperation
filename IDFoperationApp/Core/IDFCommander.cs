
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal static class IDFCommander
    {
        public static IntelMessage GetLastMessage()
        {
            IntelUnit intelUnit = IntelUnit.GetInstance();
            return intelUnit.IntelMessages[intelUnit.IntelMessages.Count - 1];
        }
        public static IntelTerrorist GetDangerousTerrorist()
        {
            IntelUnit intelUnit = IntelUnit.GetInstance();
            IntelTerrorist dangerousTerrorist = null;
            foreach (IntelTerrorist intelTerrorist in intelUnit.IntelTerrorists.Values)
            {
                if (dangerousTerrorist is null)
                {
                    dangerousTerrorist = intelTerrorist;
                }
                else if (intelTerrorist.Score > dangerousTerrorist.Score)
                {
                    dangerousTerrorist = intelTerrorist;
                }
            }
            return dangerousTerrorist;
        }
        public static IntelMessage GetDangerousMessage()
        {
            IntelUnit intelUnit = IntelUnit.GetInstance();
            string terrorist = IDFCommander.GetLastMessage().TerroristName;
            
        }
        public static IStrikeOption ChooseStrikeOption(IntelMessage intelMessage)
        {
            StrikeUnit strikeUnit = StrikeUnit.GetInstance();
            switch (intelMessage.Location)
            {
                case "Home":
                    return strikeUnit.StrikeOptionsData["Plains"][0];
                case "Car":
                    return strikeUnit.StrikeOptionsData["Artilleries"][0];
                default:
                    return strikeUnit.StrikeOptionsData["Drones"][0];
            }
        }
        public static bool ConfirmAttack(string terroristName, IStrikeOption strikeOption)
        {
            IntelUnit intelUnit = IntelUnit.GetInstance();
            if (intelUnit.IntelTerrorists[terroristName].IsAlive && strikeOption.Capacity > 0)
            {
                return true;
            }
            return false;
        }
        public static void Attack(string terroristName, IStrikeOption strikeOption)
        {
            Hamas hamas = Hamas.GetInstance();
            IntelUnit intelUnit = IntelUnit.GetInstance();
            foreach (Terrorist terrorist in hamas.Terrorists)
            {
                if (terrorist.Name == terroristName)
                {
                    terrorist.IsAlive = false;
                    intelUnit.IntelTerrorists[terroristName].IsAlive = false;
                }
            }
            strikeOption.Capacity--;
        }
        public static void AttackByDangerous()
        {
            IntelMessage intelMessage = IDFCommander.GetDangerousMessage();
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
