using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Common.Model
{
    public class SendEmailRequest
    {
        [JsonPropertyName("from")]
        public Recipient from { get; set; }

        [JsonPropertyName("to")]
        public List<Recipient> to { get; set; }

        [JsonPropertyName("cc")]
        public List<Recipient> cc { get; set; }

        [JsonPropertyName("reply_to")]
        public Recipient reply_to { get; set; }

        [JsonPropertyName("subject")]
        public string subject { get; set; }

        [JsonPropertyName("text")]
        public string text { get; set; }

        [JsonPropertyName("html")]
        public string html { get; set; }

        [JsonPropertyName("template_id")]
        public string template_id { get; set; }

        [JsonPropertyName("variables")]
        public List<Variable> variables { get; set; }

        [JsonPropertyName("attachments")]//, NullValueHandling = NullValueHandling.Ignore)]
        public List<Attachment> attachments { get; set; }
    }
}