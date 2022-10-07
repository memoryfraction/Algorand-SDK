using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorand.sdk.net.Api.ModelsV2
{
    public class StatusV2
    {
        public string catchpoint { get; set; }

        [JsonProperty("catchpoint-acquired-blocks")]
        public Int64 CatchpointAcquiredBlocks { get; set; }

        [JsonProperty("catchpoint-processed-accounts")]
        public Int64 CatchpointProcessedAccounts { get; set; }

        [JsonProperty("catchpoint-total-accounts")]
        public Int64 CatchpointTotalAccounts { get; set; }

        [JsonProperty("catchpoint-total-blocks")]
        public Int64 CatchpointTotalBlocks { get; set; }

        [JsonProperty("catchpoint-verified-accounts")]
        public Int64 CatchpointVerifiedAccounts { get; set; }

        [JsonProperty("catchup-time")]
        public Int64 CatchupTime { get; set; }

        [JsonProperty("last-catchpoint")]
        public string LastCatchpoint { get; set; }

        [JsonProperty("last-round")]
        public Int64 LastRound { get; set; }

        [JsonProperty("last-version")]
        public string LastVersion { get; set; }

        [JsonProperty("next-version")]
        public string NextVersion { get; set; }

        [JsonProperty("next-version-round")]
        public Int64 NextVersionRound { get; set; }

        [JsonProperty("next-version-supported")]
        public bool NextVersionSupported { get; set; }

        [JsonProperty("stopped-at-unsupported-round")]
        public bool StoppedAtUnsupportedRound { get; set; }

        [JsonProperty("time-since-last-round")]
        public Int64 TimeSinceLastRound { get; set; }
    }
}
