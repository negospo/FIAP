namespace FIAP.Modules.Domain.Entities.Produto
{
    public class Request
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Enums.ProdutoCategoria ProdutoCategoriaId { get; set; }
        public decimal Preco { get; set; }
        public string Imagem { get; set; }
    }
}
