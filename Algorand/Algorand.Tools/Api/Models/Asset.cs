using System.Text.Json.Serialization;

namespace Algorand.Tools.Api.Models
{
    public class Asset
    {
        [JsonPropertyName("index")]
        public string Index { get; set; }

        [JsonPropertyName("params")]
        public Params Params { get; set; }
    }
}