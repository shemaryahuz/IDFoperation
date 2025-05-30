using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal static class GeminiPrompts
    {
        public static string GetTerroristPrompt()
        {
            return "Generate a JSON object for a Terrorist with the following properties: Name (string) , Rank (int), IsAlive(bool), Weapons (list of string (each string can be 'Rifle' or 'Gun' or 'Knife'))";
        }
        public static string GetIntelMessagePrompt()
        {
            return "Generate a JSON object for a Terrorist with the following properties:";
        }
    }
}
