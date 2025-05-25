using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal static class IDFCommander
    {
        public static void ShowTerrorists(IDF idf)
        {
            Console.WriteLine("Those are the Hamas terrorists that the AMAN Unit of the IDF is Tracking after them:");
            foreach (IntelTerrorist intelTerrorist in idf.amanUnit.IntelTerrorists)
            {
                Console.WriteLine($"Name: {intelTerrorist.Name}. Rank: {intelTerrorist.Rank}. Score: {intelTerrorist.Score}. Reports: {intelTerrorist.Reports}.");
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
                    Console.Write($"\nType Of Target: ");
                    foreach (string target in machin.TypeOfTarget)
                    {
                        Console.Write($"{target} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
