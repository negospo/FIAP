namespace FIAP.Modules.Domain.Repositories
{
    public interface ICliente
    {
        public Entities.Cliente Get(int id);
        public IEnumerable<Entities.Cliente> List();
        public bool Delete(int id);
        public bool Insert(Entities.Cliente cliente);
        public bool Update(Entities.Cliente cliente);
        public Entities.Cliente GetByCpf(string cpf);
        public bool Exists(Entities.Cliente cliente);
    }
}
