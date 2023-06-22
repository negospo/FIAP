namespace FIAP.Modules.Domain.Repositories
{
    public interface IProduto
    {
        public Entities.Produto.Response Get(int id);
        public IEnumerable<Entities.Produto.Response> List();
        public IEnumerable<Entities.Produto.Response> ListByCategory(Enums.ProdutoCategoria categoria);
        public bool Delete(int id);
        public bool Insert(Entities.Produto.Request produto);
        public bool Update(Entities.Produto.Request produto);
    }
}
