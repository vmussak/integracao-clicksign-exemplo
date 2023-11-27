namespace Clicksign.Exemplo.UseCases.CreateAcceptanceTermUseCase
{
    public interface ICreateAcceptanceTermUseCase
    {
        Task<ResponseHandler> Handle(CreateAcceptanceTermRequest request, CancellationToken cancellationToken);
    }
}
