using Clicksign.Exemplo.Dtos;

namespace Clicksign.Exemplo.Repositories
{
    public interface IClickSignRepository
    {
        Task<CreateDocumentResponse?> CreateDocument(string pathName, string fileContentBase64);

        Task<CreateSignerResponse?> CreateSigner(string? document, string email, string name);

        Task<AddSignerToDocumentResponse?> AddSignerToDocument(string documentKey, string signerKey, string? message = null);
    }
}
