using FIAP.Modules.Application.DTO;
using FIAP.Modules.Domain.Entities;

namespace FIAP.Modules.Application.UseCases
{
    public interface IPedidoUseCase
    {
        public IEnumerable<DTO.Pedido.Response> List();
        public IEnumerable<DTO.Pedido.Response> ListByStatus(Domain.Enums.PedidoStatus status);
        public DTO.Pedido.Response Get(int id);
        public bool Order(DTO.Pedido.SaveRequest pedido);
        public bool UpdateOrderStatus(int id, Domain.Enums.PedidoStatus status);
    }
}
