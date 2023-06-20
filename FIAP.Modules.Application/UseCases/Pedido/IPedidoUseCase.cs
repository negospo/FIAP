using FIAP.Modules.Application.DTO;
using FIAP.Modules.Domain.Enums;

namespace FIAP.Modules.Application.UseCases
{
    public interface IPedidoUseCase
    {
        public IEnumerable<PedidoDto> List();
        public PedidoDto Get(int id);
        public PedidoDto Save(CreatePedidoDto createPedidoDto);
        public bool Delete(int id);
    }
}
