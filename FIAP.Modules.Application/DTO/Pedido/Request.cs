namespace FIAP.Modules.Application.DTO.Pedido
{
    public class Request
    {
        public int? ClienteId { get; set; }
        public bool Anonimo { get; set; }
        public string ClienteObservacao { get; set; }
        public IEnumerable<PedidoItem.Request> Itens { get; set; }
    }
}
