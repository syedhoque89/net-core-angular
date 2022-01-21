using System.Text.Json.Serialization;

namespace AppDev.Models
{
    public class VenueInformation
    {
        [JsonPropertyName("official_star_rating")]
        public int OfficialStarRating { get; init; }
    }
}