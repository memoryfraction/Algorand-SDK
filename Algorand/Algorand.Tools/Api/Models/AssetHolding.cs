using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Algorand.SDK.Dotnet.Api.Models
{
    public class AssetHolding
    {
        public double ActualBalance { get; set; }

        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        [JsonPropertyName("asset-id")]
        public string AssetId { get; set; }

        [JsonPropertyName("is-frozen")]
        public bool IsFrozen { get; set; }
    }
}
