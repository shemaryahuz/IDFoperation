using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal static class IDFCommander
    {
        private static void ShowIntelTerrorists(IDF idf)
        {
            Console.WriteLine("\nThose are the Hamas terrorists that the AMAN Unit of the IDF is Tracking after them:");
            foreach (IntelTerrorist intelTerrorist in idf.amanUnit.IntelTerrorists)
            {
                Console.WriteLine(
                    $"Name: {intelTerrorist.Name}. " +
                    $"Rank: {intelTerrorist.Rank}. " +
                    $"Score: {intelTerrorist.Score}. " +
                    $"Reports: {intelTerrorist.Reports}. " +
                    $"Status: {(intelTerrorist.IsAlive ? "Alive" : "Dead")}.");
            }
        }
        private static void ShowIntelMessages(IDF idf)
        {
            Console.WriteLine("\nThose are the Intelligance Messages That the AMAN unit of the IDF holds:");
            foreach (IntelMessage message in idf.amanUnit.Messages)
            {
                Console.WriteLine($"Terrorist Name: {message.IntelTerrorist.Name}. Location: {message.Location}. Time: {message.Time}.");
            }
        }
        private static void ShowStrikeOptions(IDF idf)
        {
            Console.WriteLine("\nThose are the macins of strike options that the Strike Unit of the IDF holds:");
            foreach (string strikOption in idf.strikeUnit.StrikeOptionsData.Keys)
            {
                Console.WriteLine($"{strikOption}:");
                foreach (IStrikeOption machin in idf.strikeUnit.StrikeOptionsData[strikOption])
                {
                    Console.Write(
                        $"Name: {machin.UniqueName}. " +
                        $"Capacity: {machin.Capacity}. " +
                        $"Bombs Type: ");
                    foreach (string bomb in machin.BombsType)
                    {
                        Console.Write($"{bomb} ");
                    }
                    Console.Write($". Type Of Target: ");
                    foreach (string target in machin.TypeOfTarget)
                    {
                        Console.Write($"{target} ");
                    }
                    Console.WriteLine();
                }
            }
        }
        private static IntelMessage ChooseTarget(IDF idf)
        {
            IntelMessage messageOfTarget = idf.amanUnit.Messages[idf.amanUnit.Messages.Count - 1];
            foreach (IntelMessage intelMessage in idf.amanUnit.Messages)
            {
                if (intelMessage.IntelTerrorist.Rank > messageOfTarget.IntelTerrorist.Rank && intelMessage.IntelTerrorist.IsAlive)
                {
                    messageOfTarget = intelMessage;
                }
            }
            return messageOfTarget;
        }
        private static IStrikeOption ChooseStrikeOption(IDF idf, IntelMessage intelMessage)
        {
            switch (intelMessage.Location)
            {
                case "Home":
                    return idf.strikeUnit.StrikeOptionsData["Plains"][0];
                case "Car":
                    return idf.strikeUnit.StrikeOptionsData["Artilleries"][0];
                default:
                    return idf.strikeUnit.StrikeOptionsData["Drones"][0];
            }
        }
        private static bool ConfirmAttack(IntelTerrorist intelTerrorist, IStrikeOption strikeOption)
        {
            if (intelTerrorist.IsAlive && strikeOption.Capacity > 0)
            {
                return true;
            }
            return false;
        }
        private static void Attack(Hamas hamas, IntelTerrorist intelTerrorist, IStrikeOption strikeOption)
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
        private static void AttackByDangerous(IDF idf, Hamas hamas)
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
        public static void Welcome(IDF idf)
        {
            Console.WriteLine($"Welcom {idf.CurrentCommander}! You Have Control on the IDF\n");
        }
        public static void ShowMenu()
        {
            Console.WriteLine(
                "\n\nThe IDF hase AMAN unit for Intelligance Information about Hamas Terrorists,\n" +
                "And Strike Unit with Strike option to Attack hamas terrorists.\n\n" +
                "Choose on of the options below (1, 2 etc.):\n" +
                "1. Show The List of Terrorist that the AMAN Unit is Tracking after them.\n" +
                "2. Show The List of Intelligance Messages that the AMAN Unit Holds.\n" +
                "3. Show The List of Strike Options that the Strike Unit Holds.\n" +
                "4. Attack a Terrorist according to the most dangerous Terrorist.\n" +
                "5. Exit.\n\n");
        }
        public static string GetChoice()
        {
            return Console.ReadLine();
        }
        public static bool ValidateChoice(string choice)
        {
            string validCoices = "12345";
            return validCoices.Contains(choice);
        }
        public static void ActivateChoice(string choice, IDF idf, Hamas hamas)
        {
            switch (choice)
            {
                case "1":
                    IDFCommander.ShowIntelTerrorists(idf);
                    break;
                case "2":
                    IDFCommander.ShowIntelMessages(idf);
                    break;
                case "3":
                    IDFCommander.ShowStrikeOptions(idf);
                    break;
                case "4":
                    IDFCommander.AttackByDangerous(idf, hamas);
                    break;
            }
        }
    }
}
