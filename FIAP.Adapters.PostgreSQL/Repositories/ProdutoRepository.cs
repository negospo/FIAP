using FIAP.Modules.Domain.Entities;
using FIAP.Modules.Domain.Enums;
using FIAP.Modules.Domain.Repositories;

namespace FIAP.Adapters.PostgreSQL.Repositories
{
    internal class ProdutoRepository : IProdutoRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Produto Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> GetByCategoria(ProdutoCategoria categoria)
        {
            throw new NotImplementedException();
        }

        public bool Save(Produto produto)
        {
            throw new NotImplementedException();
        }
    }
}
