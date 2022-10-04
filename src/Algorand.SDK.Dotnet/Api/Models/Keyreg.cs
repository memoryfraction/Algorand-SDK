using System.Text.Json.Serialization;

namespace Algorand.SDK.Dotnet.Api.Models
{
    public class Keyreg
    {
        [JsonPropertyName("selkey")]
        public string Selkey { get; set; }

        [JsonPropertyName("votefst")]
        public int Votefst { get; set; }

        [JsonPropertyName("votekd")]
        public int Votekd { get; set; }

        [JsonPropertyName("votekey")]
        public string Votekey { get; set; }

        [JsonPropertyName("votelst")]
        public int Votelst { get; set; }
    }
}