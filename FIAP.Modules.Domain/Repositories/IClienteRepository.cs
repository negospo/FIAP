namespace FIAP.Modules.Domain.Repositories
{
    public interface IClienteRepository
    {
        public Entities.Cliente Get(int id);
        public IEnumerable<Entities.Cliente> List();
        public bool Delete(int id);
        public bool Save(Entities.Cliente cliente);
        public Entities.Cliente GetByCpf(string cpf);
    }
}
