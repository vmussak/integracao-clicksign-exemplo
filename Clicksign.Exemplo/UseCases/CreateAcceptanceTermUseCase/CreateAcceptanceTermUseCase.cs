using Clicksign.Exemplo.Repositories;

namespace Clicksign.Exemplo.UseCases.CreateAcceptanceTermUseCase
{
    public class CreateAcceptanceTermUseCase : ICreateAcceptanceTermUseCase
    {
        private readonly ILogger<CreateAcceptanceTermUseCase> _logger;
        private readonly IClickSignRepository _clickSignRepository;

        public CreateAcceptanceTermUseCase(
            ILogger<CreateAcceptanceTermUseCase> logger, 
            IClickSignRepository clickSignRepository
        )
        {
            _logger = logger;
            _clickSignRepository = clickSignRepository;
        }

        public async Task<ResponseHandler> Handle(CreateAcceptanceTermRequest request, CancellationToken cancellationToken)
        {
            var termId = 10;
            var documentPdfAsBase64 = "[SEU BASE 64 AQUI]";

            //Cria o documento
            var clickSignDocument = await _clickSignRepository.CreateDocument(
                $"/term/{termId}.pdf",
                documentPdfAsBase64
            );

            if(clickSignDocument == null)
            {
                return new ResponseHandler(false, "Erro ao criar documento assinável", System.Net.HttpStatusCode.ServiceUnavailable);
            }

            //Adiciona n pessoas para assinar
            var signer1 = await _clickSignRepository.CreateSigner("CPF", "email@email.com", "Nome Completo");
            if (signer1 == null)
            {
                return new ResponseHandler(false, "Erro ao criar signatário signer1", System.Net.HttpStatusCode.ServiceUnavailable);
            }

            var signer2 = await _clickSignRepository.CreateSigner(document: null, "email2@email.com", "Nome2 Completo");
            if (signer2 == null)
            {
                return new ResponseHandler(false, "Erro ao criar signatário signer2", System.Net.HttpStatusCode.ServiceUnavailable);
            }

            //Vincula os n signatários ao documento criado
            var addContractToSigner1 = await _clickSignRepository.AddSignerToDocument(clickSignDocument.Document.Key, signer1.Signer.Key);
            if (addContractToSigner1 == null)
            {
                return new ResponseHandler(false, "Erro ao vincular signatário signer1 ao documento", System.Net.HttpStatusCode.ServiceUnavailable);
            }

            var addContractToSigner2 = await _clickSignRepository.AddSignerToDocument(clickSignDocument.Document.Key, signer2.Signer.Key);
            if (addContractToSigner2 == null)
            {
                return new ResponseHandler(false, "Erro ao vincular signatário signer2 ao documento", System.Net.HttpStatusCode.ServiceUnavailable);
            }

            return new ResponseHandler(true);
        }
    }
}
