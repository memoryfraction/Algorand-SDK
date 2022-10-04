using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Algorand.SDK.Dotnet.Api.Models
{
    public class AssetRoot
    {
        [JsonPropertyName("assets")]
        public List<AssetMain> Assets { get; set; }
    }
}