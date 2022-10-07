using Algorand.SDK.Dotnet.Api.Models;
using Newtonsoft.Json;

namespace Algorand.sdk.net.Api.ModelsV2
{
    public class AccountAssetV2
    {
        [JsonProperty("asset-holding")]
        public AssetHolding AssetHolding { get; set; }
        public int round { get; set; }
        public double Balance { get; set; }
    }
}
