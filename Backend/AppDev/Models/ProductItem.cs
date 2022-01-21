using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AppDev.Models
{
    public class ProductItem
    {
        [JsonPropertyName("url")] public string Url { get; init; }

        [JsonPropertyName("full_name")] public string FullName { get; init; }

        [JsonPropertyName("parent_location")] public string ParentLocation { get; init; }

        [JsonPropertyName("lead_product")] public LeadProduct LeadProduct { get; init; }

        [JsonPropertyName("data")] public List<VenueItemData> VenueItemData { get; init; }

        [JsonPropertyName("image")] public Image Image { get; init; }
    }

    public enum VenueType
    {
        GolfCourse,
        GolfClub,
        Resort
    }
}