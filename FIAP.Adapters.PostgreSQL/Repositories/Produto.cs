using Dapper;
using FIAP.Modules.Domain.Enums;
using FIAP.Modules.Domain.Repositories;
using static System.Net.Mime.MediaTypeNames;

namespace FIAP.Adapters.PostgreSQL.Repositories
{
    public class Produto : IProduto
    {
        /// <summary>
        /// Retorna um produto pelo id
        /// </summary>
        /// <param name="id">Id do produto</param>
        public Modules.Domain.Entities.Produto.Response Get(int id)
        {
            string query = "select * from produto where excluido = false and id = @id";
            return PostgreSQL.Database.Connection().QueryFirstOrDefault<Modules.Domain.Entities.Produto.Response>(query, new { id = id });
        }

        /// <summary>
        /// Retorna todos os produtos
        /// </summary>
        public IEnumerable<Modules.Domain.Entities.Produto.Response> List()
        {
            string query = "select * from produto where excluido = false";
            return PostgreSQL.Database.Connection().Query<Modules.Domain.Entities.Produto.Response>(query);
        }

        /// <summary>
        /// Retorna todos os produtos de uma categoria
        /// </summary>
        /// <param name="categoria">Categoria do produto</param>
        public IEnumerable<Modules.Domain.Entities.Produto.Response> ListByCategory(ProdutoCategoria categoria)
        {
            string query = "select * from produto where excluido = false and produto_categoria_id = @produto_categoria_id";
            return PostgreSQL.Database.Connection().Query<Modules.Domain.Entities.Produto.Response>(query, new
            {
                produto_categoria_id = categoria
            });
        }

        /// <summary>
        /// Deleta um produto pelo id
        /// </summary>
        /// <param name="id">Id do produto</param>
        public bool Delete(int id)
        {
            string query = "update produto set excluido = true where id = @id";
            int affected = PostgreSQL.Database.Connection().Execute(query, new { id = id });
            return (affected > 0);
        }

        /// <summary>
        /// Cria um novo produto
        /// </summary>
        /// <param name="produto">Dados do produto</param>
        public bool Insert(Modules.Domain.Entities.Produto.Request produto)
        {
            string query = "insert into produto (nome,descricao,produto_categoria_id,preco,imagem) values (@nome,@descricao,@produto_categoria_id,@preco,@imagem)";
            int affected = PostgreSQL.Database.Connection().Execute(query, new
            {
                nome = produto.Nome.Trim(),
                descricao = produto.Descricao.Trim(),
                produto_categoria_id = produto.ProdutoCategoriaId,
                preco = produto.Preco,
                imagem = produto.Imagem
            });

            return (affected > 0);
        }

     
        /// <summary>
        /// Altera um produto existente
        /// </summary>
        /// <param name="produto">Dados do produto</param>
        public bool Update(Modules.Domain.Entities.Produto.Request produto)
        {
            string query = "update produto set nome = @nome,descricao=@descricao, produto_categoria_id = @produto_categoria_id, preco = @preco,imagem = @imagem where id = @id";
            int affected = PostgreSQL.Database.Connection().Execute(query, new
            {
                id = produto.Id,
                nome = produto.Nome.Trim(),
                descricao = produto.Descricao.Trim(),
                produto_categoria_id = produto.ProdutoCategoriaId,
                preco = produto.Preco,
                imagem = produto.Imagem
            });

            return (affected > 0);
        }
    }
}
