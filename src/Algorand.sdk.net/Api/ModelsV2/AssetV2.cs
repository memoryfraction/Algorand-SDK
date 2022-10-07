using Newtonsoft.Json;
using System;

namespace Algorand.sdk.net.Api.ModelsV2
{
    public class Params
    {
        public string clawback { get; set; }
        public string creator { get; set; }
        public int decimals { get; set; }

        [JsonProperty("default-frozen")]
        public bool DefaultFrozen { get; set; }
        public string freeze { get; set; }
        public string manager { get; set; }
        public string name { get; set; }

        [JsonProperty("name-b64")]
        public string NameB64 { get; set; }
        public string reserve { get; set; }
        public long total { get; set; }

        [JsonProperty("unit-name")]
        public string UnitName { get; set; }

        [JsonProperty("unit-name-b64")]
        public string UnitNameB64 { get; set; }
    }

    public class AssetV2
    {
        public Int64 index { get; set; }
        public Params @params { get; set; }
    }

}
