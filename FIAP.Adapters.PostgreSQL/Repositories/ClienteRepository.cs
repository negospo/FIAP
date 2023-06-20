using Dapper;
using FIAP.Modules.Domain.Repositories;

namespace FIAP.Adapters.PostgreSQL.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public bool Delete(int id)
        {
            string query = "update cliente set excluido = true where id = @id";
            int affected = PostgreSQL.Database.Connection().Execute(query, new { id = id });
            return (affected > 0);
        }

        public Modules.Domain.Entities.Cliente Get(int id)
        {
            string query = "select * from cliente where excluido = false and id = @id";
            return PostgreSQL.Database.Connection().QueryFirstOrDefault<Modules.Domain.Entities.Cliente>(query, new { id = id });
        }

        public Modules.Domain.Entities.Cliente GetByCpf(string cpf)
        {
            string query = "select * from cliente where excluido = false and cpf = @cpf";
            return PostgreSQL.Database.Connection().QueryFirstOrDefault<Modules.Domain.Entities.Cliente>(query, new { cpf = cpf });
        }

        public IEnumerable<Modules.Domain.Entities.Cliente> List()
        {
            string query = "select * from cliente where excluido = false";
            return PostgreSQL.Database.Connection().Query<Modules.Domain.Entities.Cliente>(query);
        }

        public bool Update(Modules.Domain.Entities.Cliente cliente)
        {
            if (ExistsEmailOrCPF(cliente))
                throw new Exception("Ja existe outro cliente com este email ou cpf");

            string query = "update cliente set nome = @nome,email = @email, cpf = @cpf where id = @id";
            int affected = PostgreSQL.Database.Connection().Execute(query, new
            {
                id = cliente.Id,
                nome = cliente.Nome.Trim(),
                email = cliente.Email.Trim(),
                cpf = cliente.Cpf.Trim()
            });

            return (affected > 0);
        }

        public bool Insert(Modules.Domain.Entities.Cliente cliente)
        {
            if (Exists(cliente))
                throw new Exception("Cliente ja existe");

            string query = "insert into cliente (nome,email,cpf) values (@nome,@email,@cpf)";
            int affected = PostgreSQL.Database.Connection().Execute(query, new 
            {
                nome = cliente.Nome.Trim(),
                email = cliente.Email.Trim(),
                cpf = cliente.Cpf.Trim()
            });

            return (affected > 0);
        }
        public bool Exists(Modules.Domain.Entities.Cliente cliente)
        {
            string query = "select true from cliente where cpf = @cpf or email = @email";
            return PostgreSQL.Database.Connection().QueryFirstOrDefault<bool>(query, new { cpf = cliente.Cpf, email = cliente.Email });
        }

        public bool ExistsEmailOrCPF(Modules.Domain.Entities.Cliente cliente)
        {
            string query = "select true from cliente where id <> @id and (email = @email or cpf = @cpf)";
            return PostgreSQL.Database.Connection().QueryFirstOrDefault<bool>(query, new { id = cliente.Id, cpf = cliente.Cpf, email = cliente.Email });
        }
    }
}
