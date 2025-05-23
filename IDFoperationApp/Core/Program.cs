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
            Terrorist ali = new Terrorist("Ali", 3, new List<string>() { "Gun", "Gun" });
            IntelTerrorist intelTerrorist = new IntelTerrorist(ali);
            Console.WriteLine(intelTerrorist.Name, intelTerrorist.Rank, intelTerrorist.Score);
        }
    }
}
