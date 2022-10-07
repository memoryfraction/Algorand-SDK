using Newtonsoft.Json;


namespace Algorand.sdk.net.Api.ModelsV2
{
    public class TransactionsParametersV2
    {
        [JsonProperty("consensus-version")]
        public string ConsensusVersion { get; set; }
        public int fee { get; set; }

        [JsonProperty("genesis-hash")]
        public string GenesisHash { get; set; }

        [JsonProperty("genesis-id")]
        public string GenesisId { get; set; }

        [JsonProperty("last-round")]
        public int LastRound { get; set; }

        [JsonProperty("min-fee")]
        public int MinFee { get; set; }
    }
}
