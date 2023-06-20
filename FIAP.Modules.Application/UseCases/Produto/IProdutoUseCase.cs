using FIAP.Modules.Application.DTO;
using FIAP.Modules.Domain.Enums;

namespace FIAP.Modules.Application.UseCases
{
    public interface IProdutoUseCase
    {
        public ProdutoDto Get(int id);
        public ICollection<ProdutoDto> GetByCategoria(ProdutoCategoria categoria);
        public ProdutoDto Save(ProdutoDto produtoDto);
        public bool Delete(int id);
    }
}
