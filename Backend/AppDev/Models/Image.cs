using System.Text.Json.Serialization;

namespace AppDev.Models
{
    public class Image
    {
        [JsonPropertyName("title")] public string Title { get; init; }

        [JsonPropertyName("file")] public ImageFile ImageFile { get; init; }
    }
}