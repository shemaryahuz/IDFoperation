
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    // This class is responsible to the actions in IDF
    internal static class IDFCommander
    {
        public static IntelTerrorist GetDangerousTerrorist()
        {
            IntelUnit intelUnit = IntelUnit.GetInstance();
            IntelTerrorist dangerousTerrorist = null;
            foreach (IntelTerrorist intelTerrorist in intelUnit.IntelTerrorists.Values)
            {
                if (dangerousTerrorist is null && intelTerrorist.IsAlive)
                {
                    dangerousTerrorist = intelTerrorist;
                }
                else if (intelTerrorist.Score > dangerousTerrorist.Score && intelTerrorist.IsAlive)
                {
                    dangerousTerrorist = intelTerrorist;
                }
            }
            if (!dangerousTerrorist.IsAlive)
            {
                return null;
            }
            return dangerousTerrorist;
        }
        public static IntelMessage GetLastMessage()
        {
            IntelUnit intelUnit = IntelUnit.GetInstance();
            if (intelUnit.IntelMessages.Count == 0)
            {
                return null;
            }
            return intelUnit.IntelMessages[intelUnit.IntelMessages.Count - 1];
        }
        public static IntelMessage GetMessageByName(string name)
        {
            IntelUnit intelUnit = IntelUnit.GetInstance();
            foreach (IntelMessage message in intelUnit.IntelMessages)
            {
                if (message.TerroristName == name)
                {
                    return message;
                }
            }
            return null;
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
        public static void AttackByLastMessage()
        {
        }
        public static void AttackByDangerous()
        {
        }
        public static void AttackByName()
        {
        }
    }
}
