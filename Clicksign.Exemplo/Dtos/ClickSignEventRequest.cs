using System.Text.Json.Serialization;

namespace Clicksign.Exemplo.Dtos
{
    public class ClickSignEventRequest
    {
        [JsonPropertyName("event")]
        public ClickSignEventDataRequest Event { get; set; }

        [JsonPropertyName("document")]
        public ClickSignEventDocumentRequest Document { get; set; }
    }

    public class ClickSignEventDocumentRequest
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }
    }

    public class ClickSignEventDataRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("occurred_at")]
        public DateTime OcurredAt { get; set; }

        [JsonPropertyName("data")]
        public ClickSignEventDataDetailRequest Data { get; set; }
    }

    public class ClickSignEventDataDetailRequest
    {
        [JsonPropertyName("signer")]
        public ClickSignEventDataDetailSignerRequest Signer { get; set; }
    }

    public class ClickSignEventDataDetailSignerRequest
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("list_key")]
        public string ListKey { get; set; }
    }
}
