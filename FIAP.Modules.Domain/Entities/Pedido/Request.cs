namespace FIAP.Modules.Domain.Entities.Pedido
{
    public class Request
    {
        public int? ClienteId { get; set; }
        public bool Anonimo { get; set; }
        public string AnonimoIdentificador { get; set; }
        public Enums.PedidoStatus PedidoStatusId { get; set; }
        public decimal Valor { get; set; }
        public string ClienteObservacao { get; set; }
        public IEnumerable<PedidoItem.Request> Itens { get; set; }
        public Pagamento.Response DadosPagamento { get; set; }
    }
}
