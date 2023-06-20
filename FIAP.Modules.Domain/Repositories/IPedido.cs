namespace FIAP.Modules.Domain.Repositories
{
    public interface IPedido
    {
        public IEnumerable<Entities.Pedido> List();
        public IEnumerable<Entities.Pedido> ListByStatus(Enums.PedidoStatus status);
        public bool Order(Entities.Pedido pedido);
    }
}
