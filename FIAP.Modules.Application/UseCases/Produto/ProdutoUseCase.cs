using FIAP.Modules.Application.DTO;
using FIAP.Modules.Domain.Enums;
using FIAP.Modules.Domain.Repositories;

namespace FIAP.Modules.Application.UseCases
{
    public class ProdutoUseCase : IProdutoUseCase
    {
        private readonly IProduto _produtoRepository;

        public ProdutoUseCase(IProduto produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DTO.Produto.Response Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(DTO.Produto.Request produto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DTO.Produto.Response> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DTO.Produto.Response> ListByCategory(ProdutoCategoria categoria)
        {
            throw new NotImplementedException();
        }

        public bool Update(DTO.Produto.Request produto)
        {
            throw new NotImplementedException();
        }
    }
}
