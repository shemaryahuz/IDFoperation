using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class Artillery: IStrikeOption
    {
        [JsonPropertyName("uniqueName")]
        public string UniqueName { get; set; }
        [JsonPropertyName("capacity")]
        public int Capacity { get; set; }
        [JsonPropertyName("bombsType")]
        public string[] BombsType { get; set; }
        [JsonPropertyName("typeOfTarget")]
        public string[] TypeOfTarget { get; set; }
        public Artillery(string uniqueName)
        {
            this.UniqueName = uniqueName;
            this.Capacity = 20;
            this.BombsType = new string[] { "Explosive shells" };
            this.TypeOfTarget = new string[] { "Open area" };
        }
        public void Supply()
        {
            this.Capacity += 10;
        }
    }
}
