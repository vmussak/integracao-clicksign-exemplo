using System.Text.Json.Serialization;

namespace Clicksign.Exemplo.Dtos
{
    public class AddSignerToDocumentResponse
    {
        [JsonPropertyName("list")]
        public AddSignerToDocumentDataResponse List { get; set; }
    }

    public class AddSignerToDocumentDataResponse
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("request_signature_key")]
        public string RequestSignatureKey { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
