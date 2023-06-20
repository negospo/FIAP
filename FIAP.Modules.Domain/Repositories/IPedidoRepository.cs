using FIAP.Modules.Domain.Enums;

namespace FIAP.Modules.Domain.Repositories
{
    public interface IPedidoRepository
    {
        public IEnumerable<Entities.Pedido> List();
        public Entities.Pedido Get(int id); 
        public bool Save(Entities.Pedido pedido);
        public bool Delete(int id);
    }
}
