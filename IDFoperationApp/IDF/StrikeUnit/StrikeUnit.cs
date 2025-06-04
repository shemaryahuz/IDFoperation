using IDFoperationApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    // This class represents the strike Unit of the IDF, That stores all the strike options
    internal class StrikeUnit
    {
        private static StrikeUnit _Instance;
        // Constructor to init the dictionary of the strike options
        private StrikeUnit() 
        {
            StrikeOptionsData = new Dictionary<string, List<IStrikeOption>>
            {
                {"Plains", new List<IStrikeOption>() },
                {"Drones", new List<IStrikeOption>() },
                {"Artilleries", new List<IStrikeOption>() }
            };
        }
        public static StrikeUnit GetInstance()
        {
            if (_Instance is null)
            {
                _Instance = new StrikeUnit();
            }
            return _Instance;
        }
        // A dictionary of the strike options. Keys are a strings of the type, Values are lists of the strike options
        public Dictionary<string, List<IStrikeOption>> StrikeOptionsData { get; set; } = new Dictionary<string, List<IStrikeOption>>();
    }
}