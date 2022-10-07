using System.Text.Json.Serialization;

namespace Algorand.SDK.Dotnet.Api.Models
{
    public class TruncatedTransactionRoot
    {
        [JsonPropertyName("totalTxns")]
        public int TotalTxns { get; set; }

        [JsonPropertyName("truncatedTxns")]
        public TruncatedTransaction TruncatedTxns { get; set; }
    }
}