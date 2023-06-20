using Dapper;
using FIAP.Modules.Domain.Enums;
using FIAP.Modules.Domain.Repositories;

namespace FIAP.Adapters.PostgreSQL.Repositories
{
    public class Produto : IProduto
    {
        public bool Delete(int id)
        {
            string query = "update produto set excluido = true where id = @id";
            int affected = PostgreSQL.Database.Connection().Execute(query, new { id = id });
            return (affected > 0);
        }

        public Modules.Domain.Entities.Produto Get(int id)
        {
            string query = "select * from produto where excluido = false and id = @id";
            return PostgreSQL.Database.Connection().QueryFirstOrDefault<Modules.Domain.Entities.Produto>(query, new { id = id });
        }

        public bool Insert(Modules.Domain.Entities.Produto produto)
        {
            string query = "insert into produto (nome,produto_categoria_id,preco) values (@nome,@produto_categoria_id,@preco)";
            int affected = PostgreSQL.Database.Connection().Execute(query, new
            {
                nome = produto.Nome.Trim(),
                produto_categoria_id = produto.ProdutoCategoriaId,
                preco = produto.Preco
            });

            return (affected > 0);
        }

        public IEnumerable<Modules.Domain.Entities.Produto> List()
        {
            string query = "select * from produto where excluido = false";
            return PostgreSQL.Database.Connection().Query<Modules.Domain.Entities.Produto>(query);
        }

        public IEnumerable<Modules.Domain.Entities.Produto> ListByCategory(ProdutoCategoria categoria)
        {
            string query = "select * from produto where excluido = false and produto_categoria_id = @produto_categoria_id";
            return PostgreSQL.Database.Connection().Query<Modules.Domain.Entities.Produto>(query, new 
            {
                produto_categoria_id = categoria
            });
        }

        public bool Update(Modules.Domain.Entities.Produto produto)
        {
            string query = "update produto set nome = @nome,produto_categoria_id = @produto_categoria_id, preco = @preco where id = @id";
            int affected = PostgreSQL.Database.Connection().Execute(query, new
            {
                id = produto.Id,
                nome = produto.Nome.Trim(),
                produto_categoria_id = produto.ProdutoCategoriaId,
                preco = produto.Preco
            });

            return (affected > 0);
        }
    }
}
