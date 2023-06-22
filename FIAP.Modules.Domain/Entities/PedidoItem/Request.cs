namespace FIAP.Modules.Domain.Entities.PedidoItem
{
    public class Request
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}
