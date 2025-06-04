using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    // This class is responsible for printing data to the console
    internal static class Displayer
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine($"Welcome {IDF.GetInstance().CurrentCommander}! You Have Control on the IDF\n");
        }
        public static void ShowIntelTerrorists()
        {
            IntelUnit intelUnit = IntelUnit.GetInstance();
            Console.WriteLine("\nThose are the Hamas terrorists that the Intel Unit of the IDF is Tracking after them:");
            foreach (string terrorist in intelUnit.IntelTerrorists.Keys)
            {
                Console.WriteLine(
                    $"Name: {terrorist}. " +
                    $"Rank: {intelUnit.IntelTerrorists[terrorist].Rank}. " +
                    $"Score: {intelUnit.IntelTerrorists[terrorist].Score}. " +
                    $"Reports: {intelUnit.IntelTerrorists[terrorist].Reports}. " +
                    $"Status: {(intelUnit.IntelTerrorists[terrorist].IsAlive ? "Alive" : "Dead")}.");
            }
        }
        public static void ShowIntelMessages()
        {
            IntelUnit intelUnit = IntelUnit.GetInstance();
            Console.WriteLine("\nThose are the Intelligance Messages That the Intel unit of the IDF holds:");
            foreach (IntelMessage message in intelUnit.IntelMessages)
            {
                Console.WriteLine($"Terrorist Name: {message.TerroristName}. Location: {message.Location}. Time: {message.Time}.");
            }
        }
        public static void ShowStrikeOptions()
        {
            StrikeUnit strikeUnit = StrikeUnit.GetInstance();
            Console.WriteLine("\nThose are the macins of strike options that the Strike Unit of the IDF holds:");
            foreach (string strikOption in strikeUnit.StrikeOptionsData.Keys)
            {
                Console.WriteLine($"{strikOption}:");
                foreach (IStrikeOption machin in strikeUnit.StrikeOptionsData[strikOption])
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
        public static void ShowDangerousTerrorist()
        {
            IntelTerrorist terrorist = IDFCommander.GetDangerousTerrorist();
            if (terrorist is null)
            {
                Console.WriteLine("No more terrorists alive");
            }
            else
            {
                Console.WriteLine($"Dangerous Terrorist: Name: {terrorist.Name}, Rank: {terrorist.Rank}, Score: {terrorist.Score}.");
            }
        }
        public static void ShowLastMessage()
        {
            IntelMessage message = IDFCommander.GetLastMessage();
            if (message is null)
            {
                Console.WriteLine("No messages yet.");
            }
            else
            {
                Console.WriteLine($"Message: Terrorist Name: {message.TerroristName}, Location: {message.Location}, Time: {message.Time}.");
            }
        }
        public static void ShowMenu()
        {
            Console.WriteLine(
                "\n\nThe IDF has Intel unit for Intelligance Information about Hamas Terrorists,\n" +
                "And Strike Unit with Strike option to Attack hamas terrorists.\n\n" +
                "Choose on of the options below (1, 2 etc.):\n" +
                "1. Show The List of Terrorist that the Intel Unit is Tracking after them.\n" +
                "2. Show The List of Intelligance Messages that the Intel Unit Holds.\n" +
                "3. Show The List of Strike Options that the Strike Unit Holds.\n" +
                "4. Show the Dangerous terrorist that is alive.\n" +
                "5. Show the Last message of the Intel Unit.\n" +
                "6. Attack a Terrorist according to the most dangerous Terrorist.\n" +
                "7. Attack a terrorist according to the last intel message.\n" +
                "8. Exit.\n\n");
        }
        public static string GetChoice()
        {
            Console.WriteLine("Enter your choice:");
            return Console.ReadLine();
        }
    }
}
