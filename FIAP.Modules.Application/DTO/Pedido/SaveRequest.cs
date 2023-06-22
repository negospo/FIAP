namespace FIAP.Modules.Application.DTO.Pedido
{
    public class SaveRequest
    {
        public int? ClienteId { get; set; }
        public bool Anonimo { get; set; }
        public string ClienteObservacao { get; set; }
        public IEnumerable<PedidoItem.SaveRequest> Itens { get; set; }
    }
}
