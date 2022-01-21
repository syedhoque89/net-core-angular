using System.Text.Json.Serialization;

namespace AppDev.Models
{
    public class VenueItemData
    {
        [JsonPropertyName("venue_type")] public VenueType VenueType { get; init; }

        [JsonPropertyName("venue_information")]
        public VenueInformation VenueInformation { get; init; }
    }
}