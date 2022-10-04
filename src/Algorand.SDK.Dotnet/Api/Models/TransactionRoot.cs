using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Algorand.SDK.Dotnet.Api.Models
{
    public class TransactionRoot
    {
        [JsonPropertyName("transactions")]
        public List<Transaction> Transactions { get; set; }
    }
}