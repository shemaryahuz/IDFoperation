using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hamas hamas = new Hamas();
            IDF idf = new IDF(hamas);
            Console.WriteLine("Those are the macins of strike options that the Strike Unit of the IDF holds:");
            foreach (string strikOption in idf.strikeUnit.StrikeOptionsData.Keys)
            {
                Console.WriteLine($"{strikOption}:");
                foreach (IStrikeOption machin in idf.strikeUnit.StrikeOptionsData[strikOption])
                {
                    Console.WriteLine($"Name: {machin.UniqueName}. Capacity: {machin.Capacity}.");
                }
            }
            Console.WriteLine("Those are the Hamas terrorists that the AMAN Unit of the IDF is Tracking after them:");
            foreach (IntelTerrorist intelTerrorist in idf.amanUnit.IntelTerrorists)
            {
                Console.WriteLine($"Name: {intelTerrorist.Name}. Rank: {intelTerrorist.Rank}. Score: {intelTerrorist.Score}. Reports: {intelTerrorist.Reports}.");
            }
        }
    }
}
