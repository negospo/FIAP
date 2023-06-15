using FIAP.Modules.Domain.Repositories;

namespace FIAP.Adapters.PostgreSQL.Repositories
{
    public class Cliente : ICliente
    {
        public bool Delete(int id)
        {
            return true;
        }

        public Modules.Domain.Entities.Cliente Get(int id)
        {
            return new Modules.Domain.Entities.Cliente { Id = id };
        }

        public Modules.Domain.Entities.Cliente GetByCpf(string cpf)
        {
            return new Modules.Domain.Entities.Cliente
            {
                Cpf = cpf,
                Id = 10
            };
        }

        public IEnumerable<Modules.Domain.Entities.Cliente> List()
        {
            return new List<Modules.Domain.Entities.Cliente>
            {
                new Modules.Domain.Entities.Cliente{  Id = 1},
                new Modules.Domain.Entities.Cliente{ Id = 2}
            };
        }

        public bool Save(Modules.Domain.Entities.Cliente cliente)
        {
            return true;
        }
    }
}
