using IDFoperationApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{

    internal class StrikeUnit
    {
        private static StrikeUnit _Instance;
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
        public Dictionary<string, List<IStrikeOption>> StrikeOptionsData { get; set; } = new Dictionary<string, List<IStrikeOption>>();
    }
}