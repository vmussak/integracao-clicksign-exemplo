using System.Text.Json.Serialization;

namespace Clicksign.Exemplo.Dtos
{
    public class CreateSignerResponse
    {
        [JsonPropertyName("signer")]
        public CreateSignerDataResponse Signer { get; set; }
    }

    public class CreateSignerDataResponse
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }
    }
}
