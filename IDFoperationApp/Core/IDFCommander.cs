
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
            IntelMessage message = IDFCommander.GetLastMessage();
            IStrikeOption strikeOption = IDFCommander.ChooseStrikeOption(message);
            if (message is null)
            {
                Console.WriteLine("No Intel Messages yet.");
            }
            else
            {
                bool confirmed = IDFCommander.ConfirmAttack(message.TerroristName, strikeOption);
                if (!confirmed)
                {
                    Console.WriteLine("Not confirmed because the terrorist is already dead or the strikOption's capacity is empty.");
                }
                else
                {
                    IDFCommander.Attack(message.TerroristName, strikeOption);
                    Console.WriteLine($"Attack was successful. {message.TerroristName} is Dead, The {strikeOption.UniqueName} Capacity is {strikeOption.Capacity}.");
                }
            }
        }
        public static void AttackByDangerous()
        {
            IntelUnit intelUnit = IntelUnit.GetInstance();
            IntelTerrorist terrorist = IDFCommander.GetDangerousTerrorist();
            if (terrorist is null)
            {
                Console.WriteLine("No more terrorists.");
                return;
            }
            IntelMessage intelMessage = null;
            foreach (IntelMessage message in intelUnit.IntelMessages)
            {
                if (message.TerroristName == terrorist.Name)
                {
                    intelMessage = message;
                }
            }
            if (intelMessage is null)
            {
                Console.WriteLine("No messages about the dangerous terrorist that is alive.");
                return;
            }
            IStrikeOption strikeOption = IDFCommander.ChooseStrikeOption(intelMessage);
            bool confirmed = IDFCommander.ConfirmAttack(terrorist.Name, strikeOption);
            if (!confirmed)
            {
                Console.WriteLine("Not confirmed because the strikOption's capacity is empty.");
            }
            else
            {
                IDFCommander.Attack(terrorist.Name, strikeOption);
                Console.WriteLine($"Attack was successful. {terrorist.Name} is Dead, The {strikeOption.UniqueName} Capacity is {strikeOption.Capacity}.");
            }
        }
        public static void AttackByName(string terroristName)
        {
            IntelUnit intelUnit = IntelUnit.GetInstance();
            IntelMessage intelMessage = null;
            foreach (IntelMessage message in intelUnit.IntelMessages)
            {
                if (message.TerroristName == terroristName)
                {
                    intelMessage = message;
                }
            }
            if (intelMessage is null)
            {
                Console.WriteLine("No messages about this terrorist.");
                return;
            }
            IStrikeOption strikeOption = IDFCommander.ChooseStrikeOption(intelMessage);
            bool confirmed = IDFCommander.ConfirmAttack(terroristName, strikeOption);
            if (!confirmed)
            {
                Console.WriteLine("Not confirmed because the terrorist is already dead or the strikOption's capacity is empty.");
            }
            else
            {
                IDFCommander.Attack(terroristName, strikeOption);
                Console.WriteLine($"Attack was successful. {terroristName} is Dead, The {strikeOption.UniqueName} Capacity is {strikeOption.Capacity}.");
            }
        }
    }
}
