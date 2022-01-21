using System;
using System.Text.Json.Serialization;

namespace AppDev.Models
{
    public class ImageFile
    {
        [JsonPropertyName("url")] public Uri Url { get; init; }
    }
}