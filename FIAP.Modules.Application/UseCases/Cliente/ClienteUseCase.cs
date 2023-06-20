using FIAP.Modules.Application.DTO;
using FIAP.Modules.Domain.Entities;
using FIAP.Modules.Domain.Repositories;

namespace FIAP.Modules.Application.UseCases
{
    public class ClienteUseCase : IClienteUseCase
    {
        private readonly ICliente _clienteRepository;

        public ClienteUseCase(ICliente clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(DTO.Cliente.Request cliente)
        {
            throw new NotImplementedException();
        }

        public DTO.Cliente.Response Get(int id)
        {
            throw new NotImplementedException();
        }

        public DTO.Cliente.Response GetByCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        public bool Insert(DTO.Cliente.Request cliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DTO.Cliente.Response> List()
        {
            throw new NotImplementedException();
        }

        public bool Update(DTO.Cliente.Request cliente)
        {
            throw new NotImplementedException();
        }
    }
}
