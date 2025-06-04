using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DotNetEnv;
using System.Text.Json;

namespace IDFoperationApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Welcome message to the IDF Commander
            Displayer.WelcomeMessage();
            // Initialize Intel Unit (to store the Hamas terrorist's data)
            IntelUnit.GetInstance();
            // Create Terrorists by Gemini
            await FactoryManager.CreateTerrorists();
            // Create strike Options by Gemini
            await FactoryManager.CreatePlains();
            await FactoryManager.CreateDrones();
            await FactoryManager.CreateArtilleries();
            // Create Intel messages by Gemini
            await FactoryManager.CreateIntelMessage();
            // Start the operation loop
            OperationManager.Operate();
        }
    }
}
