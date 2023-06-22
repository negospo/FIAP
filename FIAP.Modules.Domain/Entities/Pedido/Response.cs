namespace FIAP.Modules.Domain.Entities.Pedido
{
    public class Response
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int? ClienteId { get; set; }
        public bool Anonimo { get; set; }
        public string AnonimoIdentificador { get; set; }
        public Enums.PedidoStatus PedidoStatusId { get; set; }
        public decimal Valor { get; set; }
        public string ClienteObservacao { get; set; }
        public IEnumerable<PedidoItem.Response> Itens { get; set; }
    }
}
