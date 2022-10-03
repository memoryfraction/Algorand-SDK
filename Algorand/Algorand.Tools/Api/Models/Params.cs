using System.Text.Json.Serialization;

namespace Algorand.Tools.Api.Models
{
    public class Params
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("creator")]
        public string Creator { get; set; }

        [JsonPropertyName("clawback")]
        public string Clawback { get; set; }
        
        [JsonPropertyName("decimals")]
        public int Decimals { get; set; }


        [JsonPropertyName("default-frozen")]
        public bool Defaultfrozen { get; set; }

        [JsonPropertyName("freeze")]
        public string Freeze { get; set; }

        [JsonPropertyName("manager")]
        public string Manager { get; set; }

        [JsonPropertyName("reserve")]
        public string Reserve { get; set; }

        [JsonPropertyName("total")]
        public long Total { get; set; }

        [JsonPropertyName("unit-name")]
        public string UnitName { get; set; }

    }
}