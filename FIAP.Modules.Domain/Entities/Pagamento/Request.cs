namespace FIAP.Modules.Domain.Entities.Pagamento
{
    public class Request
    {
        public Modules.Domain.Enums.TipoPagamento? TipoPagamentoId { get; set; }

        public string Nome { get; set; }

        public string TokenCartao { get; set; }

        public decimal Valor { get; set; }
    }
}
