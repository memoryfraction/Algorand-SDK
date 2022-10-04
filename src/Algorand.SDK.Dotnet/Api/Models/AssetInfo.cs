using System.Text.Json.Serialization;

namespace Algorand.Tools.Api.Models
{
    public class AssetInfo
    {
        [JsonPropertyName("index")]
        public string Index { get; set; }

        [JsonPropertyName("params")]
        public Params Params { get; set; }
    }
}