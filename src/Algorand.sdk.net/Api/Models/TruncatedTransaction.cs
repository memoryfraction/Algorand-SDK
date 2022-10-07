using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Algorand.SDK.Dotnet.Api.Models
{
    public class TruncatedTransaction
    {
        [JsonPropertyName("transactions")]
        public List<Transaction> Transactions { get; set; }
    }
}