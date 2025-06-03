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
        private static void ActivateChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Displayer.ShowIntelTerrorists();
                    break;
                case "2":
                    Displayer.ShowIntelMessages();
                    break;
                case "3":
                    Displayer.ShowStrikeOptions();
                    break;
                case "4":
                    IDFCommander.AttackByDangerous();
                    break;
            }
        }
        public static void Operate()
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
                    OperationManager.ActivateChoice(choice);
                }
            }
        }
    }
}
