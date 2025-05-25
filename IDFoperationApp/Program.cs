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
            bool toExit = false;
            while (!toExit)
            {
                IDFCommander.ShowMenu(idf);
                string choice = IDFCommander.GetChoice();
                if (choice == "5")
                {
                    toExit = true;
                    continue;
                }
                else if (!IDFCommander.ValidateChoice(choice))
                {
                    Console.WriteLine("Invalid Input!");
                    continue;
                }
                else
                {
                    IDFCommander.ActivateChoice(choice, idf, hamas);
                }
            }
            
        }
    }
}
