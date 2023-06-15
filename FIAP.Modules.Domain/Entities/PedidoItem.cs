namespace FIAP.Modules.Domain.Entities
{
    public class PedidoItem
    {
        public int? Id { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}
