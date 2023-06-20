using FIAP.Modules.Application.DTO;
using FIAP.Modules.Domain.Enums;
using FIAP.Modules.Domain.Repositories;

namespace FIAP.Modules.Application.UseCases
{
    public class ProdutoUseCase : IProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public ProdutoDto Get(int id)
        {
            _produtoRepository.Get(id);
            throw new NotImplementedException();
        }
        public ICollection<ProdutoDto> GetByCategoria(ProdutoCategoria categoria)
        {
            _produtoRepository.GetByCategoria(categoria);
            throw new NotImplementedException();
        }
        public ProdutoDto Save(ProdutoDto produtoDto)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int id)
        {
            _produtoRepository.Delete(id);
            return true;
        }
    }
}
