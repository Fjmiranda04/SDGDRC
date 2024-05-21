using System.Text.Json.Serialization;

namespace Common.Model
{
    public class DomainSettings
    {
        [JsonPropertyName("send_paused")]
        public bool SendPaused { get; set; }

        [JsonPropertyName("track_clicks")]
        public bool TrackClicks { get; set; }

        [JsonPropertyName("track_opens")]
        public bool TrackOpens { get; set; }

        [JsonPropertyName("track_unsubscribe")]
        public bool TrackUnsubscribe { get; set; }

        [JsonPropertyName("track_unsubscribe_html")]
        public string TrackUnsubscribeHtml { get; set; }

        [JsonPropertyName("track_unsubscribe_plain")]
        public string TrackUnsubscribePlain { get; set; }

        [JsonPropertyName("track_content")]
        public bool TrackContent { get; set; }

        [JsonPropertyName("custom_tracking_enabled")]
        public bool CustomTrackingEnabled { get; set; }

        [JsonPropertyName("custom_tracking_subdomain")]
        public string CustomTrackingSubdomain { get; set; }
    }
}