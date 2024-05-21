using System.Text.Json.Serialization;

namespace Common.Model
{
    public class Domain
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("dkim")]
        public bool Dkim { get; set; }

        [JsonPropertyName("spf")]
        public bool Spf { get; set; }

        [JsonPropertyName("mx")]
        public bool Mx { get; set; }

        [JsonPropertyName("tracking")]
        public bool Tracking { get; set; }

        [JsonPropertyName("is_verified")]
        public bool IsVerified { get; set; }

        [JsonPropertyName("is_cname_verified")]
        public bool IsCnameVerified { get; set; }

        [JsonPropertyName("is_dns_active")]
        public bool IsDnsActive { get; set; }

        [JsonPropertyName("is_cname_active")]
        public bool IsCnameActive { get; set; }

        [JsonPropertyName("is_tracking_allowed")]
        public bool IsTrackingAllowed { get; set; }

        [JsonPropertyName("has_not_queued_messages")]
        public bool HasNotQueuedMessages { get; set; }

        [JsonPropertyName("not_queued_messages_count")]
        public int NotQueuedMessagesCount { get; set; }

        [JsonPropertyName("domain_settings")]
        public DomainSettings DomainSettings { get; set; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; }
    }
}