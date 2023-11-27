using Clicksign.Exemplo.Config;
using Clicksign.Exemplo.Dtos;

namespace Clicksign.Exemplo.Repositories
{
    public class ClickSignRepository : IClickSignRepository
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ClickSignRepository> _logger;
        private readonly string _accessToken;
        public ClickSignRepository(ClickSignConfig config, HttpClient httpClient, ILogger<ClickSignRepository> logger)
        {
            _logger = logger;
            _accessToken = config.Token;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(config.Url);
        }

        public async Task<CreateDocumentResponse?> CreateDocument(string pathName, string fileContentBase64)
        {
            var documentRequest = new CreateDocumentRequest
            {
                Document = new CreateDocumentDataRequest
                {
                    AutoClose = true,
                    Locale = "pt-BR",
                    SequenceEnabled = false,
                    BlockAfterRefusal = true,
                    Path = pathName,
                    ContentBase64 = fileContentBase64
                }
            };

            try
            {
                var response = await _httpClient.PostAsJsonAsync($"api/v1/documents?access_token={_accessToken}", documentRequest);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadFromJsonAsync<CreateDocumentResponse>();
                    return responseData;
                }

                string message = $"ClickSignRepository | Erro ao criar Document: {await response.Content.ReadAsStringAsync()}";
                _logger.LogError(message);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ClickSignRepository | Erro ao criar Document");
                return null;
            }
        }

        public async Task<CreateSignerResponse?> CreateSigner(string? document, string email, string name)
        {
            var signerRequest = new CreateSignerRequest
            {
                Signer = new CreateSignerDataRequest
                {
                    Auths = new[] { "email" }, //, "sms", "whatsapp", "pix"
                    HasDocumentation = true,
                    SelfieEnabled = false,
                    LivenessEnabled = false,
                    HandwrittenEnabled = false,
                    OfficialDocumentEnabled = false,
                    FacialBiometricsEnabled = false,
                    LocationRequiredEnabled = false,
                    Documentation = document,
                    Email = email,
                    Name = name
                }
            };

            try
            {
                var response = await _httpClient.PostAsJsonAsync($"api/v1/signers?access_token={_accessToken}", signerRequest);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadFromJsonAsync<CreateSignerResponse>();
                    return responseData;
                }

                string message = $"ClickSignRepository | Erro ao criar Signer: {await response.Content.ReadAsStringAsync()}";
                _logger.LogError(message);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ClickSignRepository | Erro ao criar Signer");
                return null;
            }
        }

        public async Task<AddSignerToDocumentResponse?> AddSignerToDocument(string documentKey, string signerKey, string? message = null)
        {

            var addSignerToDocumentRequest = new AddSignerToDocumentRequest
            {
                List = new AddSignerToDocumentDataRequest
                {
                    SignAs = "sign",
                    Refusable = true,
                    Message = message,
                    DocumentKey = documentKey,
                    SignerKey = signerKey
                }
            };

            try
            {
                var response = await _httpClient.PostAsJsonAsync($"api/v1/lists?access_token={_accessToken}", addSignerToDocumentRequest);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadFromJsonAsync<AddSignerToDocumentResponse>();
                    return responseData;
                }

                string errorMessage = $"ClickSignRepository | Erro ao vincular sign no doc: {await response.Content.ReadAsStringAsync()}";
                _logger.LogError(errorMessage);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ClickSignRepository | Erro ao vincular sign no doc");
                return null;
            }
        }
    }
}
