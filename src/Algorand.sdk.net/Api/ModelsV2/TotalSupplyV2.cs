using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Algorand.sdk.net.Api.ModelsV2
{
    public class TotalSupplyV2
    {
        public long current_round { get; set; }

        [JsonProperty("online-money")]
        public long OnlineMoney { get; set; }

        [JsonProperty("total-money")]
        public long TotalMoney { get; set; }
    }
}
