using Newtonsoft.Json;
using System;

namespace Algorand.SDK.Dotnet.Api.Models
{
    public class AccountAsset
    {
        [JsonProperty("asset-holding")]
        public AssetHolding AssetHolding { get; set; }
        public int round { get; set; }
        public double Balance { get; set; }
    }
}
