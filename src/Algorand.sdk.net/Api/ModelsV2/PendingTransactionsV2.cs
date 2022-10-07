using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorand.sdk.net.Api.ModelsV2
{
    public class PendingTransactionsV2
    {
        [JsonProperty("top-transactions")]
        public List<TopTransaction> TopTransactions { get; set; }

        [JsonProperty("total-transactions")]
        public long TotalTransactions { get; set; }
    }

    public class TopTransaction
    {
        public string sig { get; set; }
        public Txn txn { get; set; }
        public Lsig lsig { get; set; }
    }

    public class Txn
    {
        public string arcv { get; set; }
        public long fee { get; set; }
        public long fv { get; set; }
        public string gen { get; set; }
        public string gh { get; set; }
        public long lv { get; set; }
        public string note { get; set; }
        public string snd { get; set; }
        public string type { get; set; }
        public long xaid { get; set; }
        public long? aamt { get; set; }
        public List<string> apaa { get; set; }
        public long? apid { get; set; }
        public string grp { get; set; }
        public List<long> apfa { get; set; }
        public long? apan { get; set; }
        public long? amt { get; set; }
        public string rcv { get; set; }
        public List<long> apas { get; set; }
        public Apar apar { get; set; }
    }

    public class Apar
    {
        public string am { get; set; }
        public string an { get; set; }
        public string au { get; set; }
        public string c { get; set; }
        public bool df { get; set; }
        public string f { get; set; }
        public string m { get; set; }
        public string r { get; set; }
        public long t { get; set; }
        public string un { get; set; }
    }

    public class Lsig
    {
        public string l { get; set; }
    }
}
