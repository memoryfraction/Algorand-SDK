using Newtonsoft.Json;
using System;

namespace Algorand.SDK.Dotnet.Api.Models
{
    public class AssetHolding
    {
        public Int64 amount { get; set; }

        [JsonProperty("asset-id")]
        public int AssetId { get; set; }

        [JsonProperty("is-frozen")]
        public bool IsFrozen { get; set; }
    }
}
