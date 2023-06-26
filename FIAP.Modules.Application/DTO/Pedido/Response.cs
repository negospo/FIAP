using FIAP.Modules.Domain.Enums;

namespace FIAP.Modules.Application.DTO.Pedido
{
    public class Response
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int? ClienteId { get; set; }
        public bool Anonimo { get; set; }
        public string? AnonimoIdentificador { get; set; }
        public PedidoStatus PedidoStatusId { get; set; }
        public decimal Valor { get; set; }
        public string ClienteObservacao { get; set; }
        public IEnumerable<PedidoItem.Response> Itens { get; set; }
        public TipoPagamento TipoPagamentoId { get; set; }
    }
}
