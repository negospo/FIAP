using FIAP.Modules.Application.DTO;
using FIAP.Modules.Domain.Enums;
using FIAP.Modules.Domain.Repositories;

namespace FIAP.Modules.Application.UseCases
{
    public class PedidoUseCase : IPedidoUseCase
    {
        private readonly IPedido _pedidoRepository;

        public PedidoUseCase(IPedido pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public IEnumerable<DTO.Pedido.Response> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DTO.Pedido.Response> ListByStatus(PedidoStatus status)
        {
            throw new NotImplementedException();
        }

        public bool Order(DTO.Pedido.Request pedido)
        {
            throw new NotImplementedException();
        }
    }
}
