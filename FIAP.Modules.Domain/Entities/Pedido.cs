namespace FIAP.Modules.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int? ClienteId { get; set; }
        public bool Anonimo { get; set; }
        public string AnonimoIdentificador { get; set; }
        public Enums.PedidoStatus PedidoStatusId { get; set; }
        public decimal Valor { get; set; }
        public string ClienteObservacao { get; set; }
        public List<PedidoItem> Itens { get; set; }
    }
}
