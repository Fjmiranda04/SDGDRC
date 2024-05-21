using System.Text.Json.Serialization;

namespace Common.Model
{
    public class Recipient
    {
        [JsonPropertyName("email")]
        public string email { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }
    }
}