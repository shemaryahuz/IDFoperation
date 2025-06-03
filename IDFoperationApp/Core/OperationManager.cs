using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal static class OperationManager
    {
        private static bool ValidateChoice(string choice)
        {
            string[] validCoices = { "1", "2", "3", "4", "5" };
            return validCoices.Contains(choice);
        }
        private static void ActivateChoice(string choice, IDF idf, Hamas hamas)
        {
            switch (choice)
            {
                case "1":
                    Displayer.ShowIntelTerrorists(idf);
                    break;
                case "2":
                    Displayer.ShowIntelMessages(idf);
                    break;
                case "3":
                    Displayer.ShowStrikeOptions(idf);
                    break;
                case "4":
                    IDFCommander.AttackByDangerous(idf, hamas);
                    break;
            }
        }
        private static void Operate(IDF idf, Hamas hamas)
        {
            bool toExit = false;
            while (!toExit)
            {
                Displayer.ShowMenu();
                string choice = Displayer.GetChoice();
                if (choice == "5")
                {
                    toExit = true;
                    continue;
                }
                else if (!OperationManager.ValidateChoice(choice))
                {
                    Console.WriteLine("Invalid Input!");
                    continue;
                }
                else
                {
                    OperationManager.ActivateChoice(choice, idf, hamas);
                }
            }
        }
        public static void Start()
        {
            Hamas hamas = Hamas.GetInstans();
            IDF idf = IDF.GetInstance(hamas);
            Displayer.WelcomeMessage(idf);
            OperationManager.Operate(idf, hamas);
        }
    }
}
