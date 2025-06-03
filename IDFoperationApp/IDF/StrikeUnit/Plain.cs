using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class Plain : IStrikeOption
    {
        [JsonPropertyName("uniqueName")]
        public string UniqueName { get; set; }
        [JsonPropertyName("capacity")]
        public int Capacity { get; set; }
        [JsonPropertyName("bombsType")]
        public string[] BombsType { get; set; }
        [JsonPropertyName("typeOfTarget")]
        public string[] TypeOfTarget { get; set; }
        public Plain(string uniqueName)
        {
            this.UniqueName = uniqueName;
            this.Capacity = 8;
            this.BombsType = new string[] { "0.5 ton", "1 ton" };
            this.TypeOfTarget = new string[] { "Buildings" };
        }
        public void Supply()
        {
            this.Capacity += 4;
        }
    }
}
