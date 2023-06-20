using FIAP.Modules.Domain.Enums;

namespace FIAP.Modules.Domain.Repositories
{
    public interface IProdutoRepository
    {
        public Entities.Produto Get(int id);
        public IEnumerable<Entities.Produto> GetByCategoria(ProdutoCategoria categoria);
        public bool Save(Entities.Produto produto);
        public bool Delete(int id);
    }
}

