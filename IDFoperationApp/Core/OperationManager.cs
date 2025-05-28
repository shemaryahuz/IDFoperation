using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    /// <summary>
    /// Manages main operations and user choices for the application.
    /// </summary>
    internal static class OperationManager
    {
        /// <summary>
        /// Checks if the user's menu choice is valid.
        /// </summary>
        /// <param name="choice">User input choice.</param>
        /// <returns>True if valid, otherwise false.</returns>
        private static bool ValidateChoice(string choice)
        {
            string[] validCoices = { "1", "2", "3", "4", "5" };
            return validCoices.Contains(choice);
        }
        /// <summary>
        /// Executes the action corresponding to the user's choice.
        /// </summary>
        /// <param name="choice">User input choice.</param>
        /// <param name="idf">IDF instance.</param>
        /// <param name="hamas">Hamas instance.</param>
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
        /// <summary>
        /// Runs the main operation loop, handling user input and actions.
        /// </summary>
        /// <param name="idf">IDF instance.</param>
        /// <param name="hamas">Hamas instance.</param>
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
        /// <summary>
        /// Initializes and starts the operation manager.
        /// </summary>
        public static void Start()
        {
            Hamas hamas = Hamas.GetInstans();
            IDF idf = IDF.GetInstance(hamas);
            Displayer.WelcomeMessage(idf);
            OperationManager.Operate(idf, hamas);
        }
    }
}
