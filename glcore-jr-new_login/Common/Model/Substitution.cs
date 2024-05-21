using System.Text.Json.Serialization;

namespace Common.Model
{
    public class Substitution
    {
        [JsonPropertyName("var")]
        public string var { get; set; }

        [JsonPropertyName("value")]
        public string value { get; set; }
    }
}