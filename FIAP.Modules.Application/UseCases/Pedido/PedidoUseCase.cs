using FIAP.Modules.Application.DTO;
using FIAP.Modules.Domain.Repositories;

namespace FIAP.Modules.Application.UseCases
{
    public class PedidoUseCase : IPedidoUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoUseCase(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
        public IEnumerable<PedidoDto> List()
        {
            _pedidoRepository.List();   
            throw new NotImplementedException();
        }
        public PedidoDto Get(int id)
        {
            _pedidoRepository.Get(id);
            throw new NotImplementedException();
        }
        public PedidoDto Save(CreatePedidoDto createPedidoDto)
        {
            
            throw new NotImplementedException();
        }
        public bool Delete(int id)
        {
            _pedidoRepository.Delete(id);
            throw new NotImplementedException();
        }
    }
}
