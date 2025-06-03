using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal static class Displayer
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine($"Welcome {IDF.GetInstance().CurrentCommander}! You Have Control on the IDF\n");
        }
        public static void ShowIntelTerrorists()
        {
            Console.WriteLine("\nThose are the Hamas terrorists that the Intel Unit of the IDF is Tracking after them:");
            foreach (IntelTerrorist intelTerrorist in IDF.GetInstance().IntelUnit.IntelTerrorists)
            {
                Console.WriteLine(
                    $"Name: {intelTerrorist.Name}. " +
                    $"Rank: {intelTerrorist.Rank}. " +
                    $"Score: {intelTerrorist.Score}. " +
                    $"Reports: {intelTerrorist.Reports}. " +
                    $"Status: {(intelTerrorist.IsAlive ? "Alive" : "Dead")}.");
            }
        }
        public static void ShowIntelMessages()
        {
            Console.WriteLine("\nThose are the Intelligance Messages That the Intel unit of the IDF holds:");
            foreach (IntelMessage message in IDF.GetInstance().IntelUnit.Messages)
            {
                Console.WriteLine($"Terrorist Name: {message.IntelTerrorist.Name}. Location: {message.Location}. Time: {message.Time}.");
            }
        }
        public static void ShowStrikeOptions()
        {
            Console.WriteLine("\nThose are the macins of strike options that the Strike Unit of the IDF holds:");
            foreach (string strikOption in IDF.GetInstance().StrikeUnit.StrikeOptionsData.Keys)
            {
                Console.WriteLine($"{strikOption}:");
                foreach (IStrikeOption machin in IDF.GetInstance().StrikeUnit.StrikeOptionsData[strikOption])
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
        public static void ShowMenu()
        {
            Console.WriteLine(
                "\n\nThe IDF has Intel unit for Intelligance Information about Hamas Terrorists,\n" +
                "And Strike Unit with Strike option to Attack hamas terrorists.\n\n" +
                "Choose on of the options below (1, 2 etc.):\n" +
                "1. Show The List of Terrorist that the Intel Unit is Tracking after them.\n" +
                "2. Show The List of Intelligance Messages that the Intel Unit Holds.\n" +
                "3. Show The List of Strike Options that the Strike Unit Holds.\n" +
                "4. Attack a Terrorist according to the most dangerous Terrorist.\n" +
                "5. Exit.\n\n");
        }
        public static string GetChoice()
        {
            Console.WriteLine("Enter your choice:");
            return Console.ReadLine();
        }
    }
}
