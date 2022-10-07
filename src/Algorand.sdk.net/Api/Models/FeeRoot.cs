using System.Text.Json.Serialization;

namespace Algorand.SDK.Dotnet.Api.Models
{
    public class FeeRoot
    {
        [JsonPropertyName("fee")]
        public int Fee { get; set; }
    }
}