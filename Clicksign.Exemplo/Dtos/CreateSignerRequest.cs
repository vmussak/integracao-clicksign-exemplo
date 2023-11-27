using System.Text.Json.Serialization;

namespace Clicksign.Exemplo.Dtos
{
    public class CreateSignerRequest
    {
        [JsonPropertyName("signer")]
        public CreateSignerDataRequest Signer { get; set; }
    }

    public class CreateSignerDataRequest
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("auths")]
        public string[] Auths { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("documentation")]
        public string? Documentation { get; set; }

        [JsonPropertyName("has_documentation")]
        public bool HasDocumentation { get; set; }

        [JsonPropertyName("selfie_enabled")]
        public bool SelfieEnabled { get; set; }

        [JsonPropertyName("handwritten_enabled")]
        public bool HandwrittenEnabled { get; set; }

        [JsonPropertyName("location_required_enabled")]
        public bool LocationRequiredEnabled { get; set; }

        [JsonPropertyName("official_document_enabled")]
        public bool OfficialDocumentEnabled { get; set; }

        [JsonPropertyName("liveness_enabled")]
        public bool LivenessEnabled { get; set; }

        [JsonPropertyName("facial_biometrics_enabled")]
        public bool FacialBiometricsEnabled { get; set; }
    }
}