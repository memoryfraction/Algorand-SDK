using Algorand.SDK.Dotnet.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorand.sdk.net.Api.ModelsV2
{
    public class VersionV2
    {
        public List<string> versions { get; set; }
        public string genesis_id { get; set; }
        public string genesis_hash_b64 { get; set; }
        public Build build { get; set; }
    }

    public class Build
    {
        public int major { get; set; }
        public int minor { get; set; }
        public int build_number { get; set; }
        public string commit_hash { get; set; }
        public string branch { get; set; }
        public string channel { get; set; }
    }


}
