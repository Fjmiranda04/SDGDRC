using System.Text.Json.Serialization;

namespace Common.Model
{
    public class Root
    {
        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }
}