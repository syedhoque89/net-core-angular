using System.Text.Json.Serialization;

namespace AppDev.Models
{
    public class LeadProduct
    {
        [JsonPropertyName("rounds")] public int Rounds { get; init; }

        [JsonPropertyName("nights")] public int Nights { get; init; }

        [JsonPropertyName("price")] public double Price { get; init; }

        [JsonPropertyName("badge")] public string Badge { get; init; }
    }
}