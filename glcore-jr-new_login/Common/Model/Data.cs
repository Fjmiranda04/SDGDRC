using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Common.Model
{
    public class Data
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("emails")]
        public List<object> Emails { get; set; }

        [JsonPropertyName("domain")]
        public Domain Domain { get; set; }
    }
}