using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AppDev.Models
{
    public class ProductList
    {
        [JsonPropertyName("product_lists")] public List<Product> Products { get; init; }
    }
}