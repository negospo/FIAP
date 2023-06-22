namespace FIAP.Modules.Domain.Repositories
{
    public interface ICliente
    {
        public Entities.Cliente.Response Get(int id);
        public IEnumerable<Entities.Cliente.Response> List();
        public bool Delete(int id);
        public bool Insert(Entities.Cliente.Request cliente);
        public bool Update(Entities.Cliente.Request cliente);
        public Entities.Cliente.Response GetByCpf(string cpf);
        public bool Exists(Entities.Cliente.Request cliente);
    }
}
