namespace FIAP.Modules.Domain.Entities.Pagamento
{
    public class Response
    {
        public string CodigoTransacao { get; set; }
        public string Status { get; set; }
        public decimal Valor { get; set; }
        public Enums.TipoPagamento TipoPagamentoId { get; set; }
    }
}
