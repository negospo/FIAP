namespace FIAP.Modules.Domain.Services
{
    public interface IPagamentoGateway
    {
        public Entities.Pagamento.Response ProcessPayment(Entities.Pagamento.Request request);
    }
}
