namespace FIAP.Modules.Domain.Repositories
{
    public interface IProduto
    {
        public Entities.Produto Get(int id);
        public IEnumerable<Entities.Produto> List();
        public IEnumerable<Entities.Produto> ListByCategory(Enums.ProdutoCategoria categoria);
        public bool Delete(int id);
        public bool Insert(Entities.Produto produto);
        public bool Update(Entities.Produto produto);
    }
}
