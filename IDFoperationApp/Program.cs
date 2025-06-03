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
            Displayer.WelcomeMessage();
            
            Env.Load(@"..\..\.env");
            string apiKey = Environment.GetEnvironmentVariable("GEMINI_API_KEY");

            OperationManager.Operate();
        }
    }
}
