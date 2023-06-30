namespace FIAP.Adapters.Payment
{
    public class MercadoPago : Modules.Domain.Services.IPagamentoGateway
    {
        public Modules.Domain.Entities.Pagamento.Response ProcessPayment(Modules.Domain.Entities.Pagamento.Request request)
        {
            //MOCK de retorna de uma chamada a um gateway de pagamento Externo
            return new Modules.Domain.Entities.Pagamento.Response
            {
                Status = "Sucess",
                CodigoTransacao = Guid.NewGuid().ToString(),
                Valor = request.Valor,
                TipoPagamentoId = request.TipoPagamentoId.Value
            };
        }
    }
}
