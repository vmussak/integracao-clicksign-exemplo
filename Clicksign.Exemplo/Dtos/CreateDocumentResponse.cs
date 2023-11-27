using System.Text.Json.Serialization;

namespace Clicksign.Exemplo.Dtos
{
    public class CreateDocumentResponse
    {
        [JsonPropertyName("document")]
        public CreateDocumentResponseData Document { get; set; }
    }

    public class CreateDocumentResponseData
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }
    }
}
