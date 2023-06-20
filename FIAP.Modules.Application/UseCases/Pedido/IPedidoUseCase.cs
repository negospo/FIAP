using FIAP.Modules.Application.DTO;
using FIAP.Modules.Domain.Entities;

namespace FIAP.Modules.Application.UseCases
{
    public interface IPedidoUseCase
    {
        public IEnumerable<DTO.Pedido.Response> List();
        public IEnumerable<DTO.Pedido.Response> ListByStatus(Domain.Enums.PedidoStatus status);
        public bool Order(DTO.Pedido.Request pedido);
    }
}
