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
            Terrorist t = new Terrorist("ali", 3, new List<string>() { "Rifle", "Gun" });
            IntelTerrorist it = new IntelTerrorist(t);
            Console.WriteLine($"{it.Name} {it.Rank} {it.Score}");
        }
    }
}
