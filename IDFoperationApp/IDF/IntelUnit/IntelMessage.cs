using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    // This class represents an Inteligance Message about a terrorist 
    internal class IntelMessage
    {
        [JsonPropertyName("terroristName")]
        public string TerroristName { get; set; }
        [JsonPropertyName("location")]
        public string Location { get; set; }
        [JsonPropertyName("time")]
        public DateTime Time;
        public IntelMessage(string terroristName, string location)
        {
            this.TerroristName = terroristName;
            this.Location = location;
            this.Time = DateTime.Now;
        }
    }
}
