namespace FIAP.Modules.Domain.Repositories
{
    public interface IPedido
    {
        public IEnumerable<Entities.Pedido.Response> List();
        public IEnumerable<Entities.Pedido.Response> ListByStatus(Enums.PedidoStatus status);
        public Entities.Pedido.Response Get(int id);
        public bool Order(Entities.Pedido.Request pedido);
        public bool UpdateOrderStatus(int id, Enums.PedidoStatus status);


    }
}
