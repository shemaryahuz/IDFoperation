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
            FactoryManager factory = FactoryManager.GetInstance();
            await factory.CreateTerrorists();
            foreach (Terrorist terrorist in Hamas.GetInstance().Terrorists)
            {
                Console.WriteLine(
                    $"Name: {terrorist.Name}. " +
                    $"Rank: {terrorist.Rank}. " +
                    $"Status: {(terrorist.IsAlive ? "Alive" : "Dead")}. " +
                    $"Weapons: {terrorist.Weapons[0]}");
            }

            //OperationManager.Operate();
        }
    }
}
