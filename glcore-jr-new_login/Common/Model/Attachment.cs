using System.Text.Json.Serialization;

namespace Common.Model
{
    public class Attachment
    {
        [JsonPropertyName("content")]
        public string content { get; set; }

        [JsonPropertyName("filename")]
        public string filename { get; set; }
    }
}