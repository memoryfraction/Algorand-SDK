using System.Text.Json.Serialization;

namespace Algorand.SDK.Dotnet.Api.Models
{
    public class Curfrz
    {
        [JsonPropertyName("acct")]
        public string Acct { get; set; }

        [JsonPropertyName("freeze")]
        public bool Freeze { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}