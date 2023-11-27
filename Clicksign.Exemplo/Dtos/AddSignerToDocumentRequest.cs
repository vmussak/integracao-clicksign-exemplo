using System.Text.Json.Serialization;

namespace Clicksign.Exemplo.Dtos
{
    public class AddSignerToDocumentRequest
    {
        [JsonPropertyName("list")]
        public AddSignerToDocumentDataRequest List { get; set; }
    }

    public class AddSignerToDocumentDataRequest
    {
        [JsonPropertyName("document_key")]
        public string DocumentKey { get; set; }

        [JsonPropertyName("signer_key")]
        public string SignerKey { get; set; }

        [JsonPropertyName("sign_as")]
        public string SignAs { get; set; }

        [JsonPropertyName("refusable")]
        public bool Refusable { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}
