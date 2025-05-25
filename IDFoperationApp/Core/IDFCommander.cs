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
            Console.WriteLine("Those are the Hamas terrorists that the AMAN Unit of the IDF is Tracking after them:");
            foreach (IntelTerrorist intelTerrorist in idf.amanUnit.IntelTerrorists)
            {
                Console.WriteLine($"Name: {intelTerrorist.Name}. Rank: {intelTerrorist.Rank}. Score: {intelTerrorist.Score}. Reports: {intelTerrorist.Reports}.");
            }
        }
        public static void ShowIntelMessages(IDF idf)
        {
            Console.WriteLine("Those are the Intelligance Messages That the AMAN unit of the IDF holds:");
            foreach (IntelMessage message in idf.amanUnit.Messages)
            {
                Console.WriteLine($"Terrorist Name: {message.IntelTerrorist.Name}. Location: {message.Location}. Time: {message.Time}.");
            }
        }
        public static void ShowStrikeOptions(IDF idf)
        {
            Console.WriteLine("Those are the macins of strike options that the Strike Unit of the IDF holds:");
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
                Console.WriteLine($"The Attack was successful! {intelMessage.IntelTerrorist} is dead!");
            }
            else if (!intelMessage.IntelTerrorist.IsAlive)
            {
                Console.WriteLine($"{intelMessage.IntelTerrorist} is already dead.");
            }
            else
            {
                Console.WriteLine($"There are not enough bombs for the {strikeOption.UniqueName}, Please Suplly.");
            }
        }
        public static void ShowMenue(IDF idf)
        {
            Console.WriteLine(
                $"Welcom {idf.CurrentCommander}! You Have Control on the IDF.\n" +
                "The IDF hase AMAN unit for Intelligance Information about Hamas Terrorists,\n" +
                "And Strike Unit with Strike option to Attack hamas terrorists.\n" +
                "Choose on of the options below:\n" +
                "1. Show The List of Terrorist that the AMAN Unit is Tracking after them.\n" +
                "2. Show The List of Intelligance Messages that the AMAN Unit Holds.\n" +
                "3. Show The List of Strike Options that the Strike Unit Holds.\n" +
                "4. Attack a Terrorist according to last messages and the most dangerous Terrorist.\n" +
                "5. Exit.");
        }
        public static void GetChoice()
        {

        }
    }
}
