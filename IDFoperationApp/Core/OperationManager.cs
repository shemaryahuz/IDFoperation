using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    // This class is responsible for the management of the IDFoperation, using the Displayer and IDFcommander
    internal static class OperationManager
    {
        private static bool ValidateChoice(string choice)
        {
            string[] validCoices = { "1", "2", "3", "4", "5", "6", "7" };
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
                    Displayer.ShowDangerousTerrorist();
                    break;
                case "5":
                    Displayer.ShowLastMessage();
                    break;
                case "6":
                    IDFCommander.AttackByDangerous();
                    break;
                case "7":
                    IDFCommander.AttackByLastMessage();
                    break;
            }
        }
        public static void Operate()
        {
            bool toExit = false;
            string exit = "8";
            while (!toExit)
            {
                Displayer.ShowMenu();
                string choice = Displayer.GetChoice();
                if (choice == exit)
                {
                    toExit = true;
                }
                else if (!OperationManager.ValidateChoice(choice))
                {
                    Console.WriteLine("Invalid Input!");
                }
                else
                {
                    OperationManager.ActivateChoice(choice);
                }
            }
        }
    }
}
