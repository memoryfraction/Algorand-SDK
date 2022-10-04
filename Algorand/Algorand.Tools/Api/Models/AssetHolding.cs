using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Algorand.SDK.Dotnet.Api.Models
{
    public class AssetHolding
    {
        public int amount { get; set; }

        [JsonProperty("asset-id")]
        public int AssetId { get; set; }

        [JsonProperty("is-frozen")]
        public bool IsFrozen { get; set; }
    }
}
