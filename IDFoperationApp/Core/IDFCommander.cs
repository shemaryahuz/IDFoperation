using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal static class IDFCommander
    {
        public static void ShowIntelTerrorists(IDF idf)
        {
            Console.WriteLine("\nThose are the Hamas terrorists that the AMAN Unit of the IDF is Tracking after them:");
            foreach (IntelTerrorist intelTerrorist in idf.amanUnit.IntelTerrorists)
            {
                Console.WriteLine($"Name: {intelTerrorist.Name}. Rank: {intelTerrorist.Rank}. Score: {intelTerrorist.Score}. Reports: {intelTerrorist.Reports}.");
            }
        }
        public static void ShowIntelMessages(IDF idf)
        {
            Console.WriteLine("\nThose are the Intelligance Messages That the AMAN unit of the IDF holds:");
            foreach (IntelMessage message in idf.amanUnit.Messages)
            {
                Console.WriteLine($"Terrorist Name: {message.IntelTerrorist.Name}. Location: {message.Location}. Time: {message.Time}.");
            }
        }
        public static void ShowStrikeOptions(IDF idf)
        {
            Console.WriteLine("\nThose are the macins of strike options that the Strike Unit of the IDF holds:");
            foreach (string strikOption in idf.strikeUnit.StrikeOptionsData.Keys)
            {
                Console.WriteLine($"{strikOption}:");
                foreach (IStrikeOption machin in idf.strikeUnit.StrikeOptionsData[strikOption])
                {
                    Console.Write(
                        $"Name: {machin.UniqueName}." +
                        $"Capacity: {machin.Capacity}." +
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
        public static void Attack(IDF idf, Hamas hamas)
        {
            IntelMessage intelMessage = idf.ChooseTarget();
            IStrikeOption strikeOption = idf.ChooseStrikeOption(intelMessage);
            bool confirmed = idf.ConfirmAttack(intelMessage.IntelTerrorist, strikeOption);
            if (confirmed)
            {
                idf.Attack(hamas, intelMessage.IntelTerrorist, strikeOption);
                Console.WriteLine($"The Attack was successful! {intelMessage.IntelTerrorist.Name} is dead!");
            }
            else if (!intelMessage.IntelTerrorist.IsAlive)
            {
                Console.WriteLine($"{intelMessage.IntelTerrorist.Name} is already dead.");
            }
            else
            {
                Console.WriteLine($"There are not enough bombs for the {strikeOption.UniqueName}, Please Suplly.");
            }
        }
        public static void Welcome(IDF idf)
        {
            Console.WriteLine($"Welcom {idf.CurrentCommander}! You Have Control on the IDF\n");
        }
        public static void ShowMenu()
        {
            Console.WriteLine(
                "The IDF hase AMAN unit for Intelligance Information about Hamas Terrorists,\n" +
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
                    IDFCommander.Attack(idf, hamas);
                    break;
            }
        }
    }
}
