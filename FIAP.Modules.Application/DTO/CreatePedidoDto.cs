using FIAP.Modules.Domain.Entities;

namespace FIAP.Modules.Application.DTO
{
    public class CreatePedidoDto
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int? ClienteId { get; set; }
        public bool Anonimo { get; set; }
        public string ClienteObservacao { get; set; }
        public List<PedidoItem> Itens { get; set; }
    }
}
