using FIAP.Modules.Application.DTO.Produto;
using FIAP.Modules.Domain.Enums;

namespace FIAP.Modules.Application.UseCases
{
    public class ProdutoUseCase : IProdutoUseCase
    {
        private readonly Domain.Repositories.IProduto _produtoRepository;

        public ProdutoUseCase(Domain.Repositories.IProduto produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public bool Delete(int id)
        {
            return _produtoRepository.Delete(id);
        }

        public Response Get(int id)
        {
            var result = _produtoRepository.Get(id);
            if (result == null)
                return null;

            return new Response
            {
                Id = result.Id,
                Nome = result.Nome,
                Descricao = result.Descricao,
                Preco = result.Preco,
                ProdutoCategoriaId = result.ProdutoCategoriaId,
                Imagem = result.Imagem
            };
        }

        public bool Insert(SaveRequest produto)
        {
            var newProd = new Domain.Entities.Produto.Request
            {
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco.Value,
                ProdutoCategoriaId = produto.ProdutoCategoriaId,
                Imagem = produto.Imagem
            };

            return _produtoRepository.Insert(newProd);
        }

        public IEnumerable<Response> List()
        {
            var result = _produtoRepository.List().Select(s => new Response
            {
                Id = s.Id,
                Nome = s.Nome,
                Descricao = s.Descricao,
                Preco = s.Preco,
                ProdutoCategoriaId = s.ProdutoCategoriaId,
                Imagem = s.Imagem
            }).ToList();

            return result;
        }

        public IEnumerable<Response> ListByCategory(ProdutoCategoria categoria)
        {
            var result = _produtoRepository.ListByCategory(categoria).Select(s => new Response
            {
                Id = s.Id,
                Nome = s.Nome,
                Descricao = s.Descricao,
                Preco = s.Preco,
                ProdutoCategoriaId = s.ProdutoCategoriaId,
                Imagem = s.Imagem
            }).ToList();

            return result;
        }

        public bool Update(UpdateRequest produto)
        {
            var newProd = new Domain.Entities.Produto.Request
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco.Value,
                ProdutoCategoriaId = produto.ProdutoCategoriaId,
                Imagem = produto.Imagem
            };

            return _produtoRepository.Update(newProd);
        }
    }
}
