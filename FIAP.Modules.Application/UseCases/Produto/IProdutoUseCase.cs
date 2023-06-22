using FIAP.Modules.Domain.Enums;

namespace FIAP.Modules.Application.UseCases
{
    public interface IProdutoUseCase
    {
        public DTO.Produto.Response Get(int id);
        public IEnumerable<DTO.Produto.Response> List();
        public IEnumerable<DTO.Produto.Response> ListByCategory(ProdutoCategoria categoria);
        public bool Delete(int id);
        public bool Insert(DTO.Produto.SaveRequest produto);
        public bool Update(DTO.Produto.UpdateRequest produto);
    }
}
