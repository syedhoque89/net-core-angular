using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AppDev.Models
{
    public class Product
    {
        [JsonPropertyName("title")] public string Title { get; init; }

        [JsonPropertyName("items")] public List<ProductItem> Items { get; init; }
    }
}