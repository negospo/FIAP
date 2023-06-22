using FIAP.Modules.Application.DTO.Cliente;
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
            return _clienteRepository.Delete(id);
        }

        public bool Exists(DTO.Cliente.SaveRequest cliente)
        {
            var request = new Domain.Entities.Cliente.Request
            {
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                Email = cliente.Email
            };

            return _clienteRepository.Exists(request);
        }

        public bool Exists(DTO.Cliente.UpdateRequest cliente)
        {
            var request = new Domain.Entities.Cliente.Request
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                Email = cliente.Email
            };

            return _clienteRepository.Exists(request);
        }


        public DTO.Cliente.Response Get(int id)
        {
            var result = _clienteRepository.Get(id);
            if (result == null)
                return null;

            return new DTO.Cliente.Response
            {
                Id = result.Id,
                Nome = result.Nome,
                Cpf = result.Cpf,
                Email = result.Email
            };
        }

        public Response GetByCpf(string cpf)
        {
            var result = _clienteRepository.GetByCpf(cpf);
            if (result == null)
                return null;

            return new DTO.Cliente.Response
            {
                Id = result.Id,
                Nome = result.Nome,
                Cpf = result.Cpf,
                Email = result.Email
            };
        }

        public bool Insert(DTO.Cliente.SaveRequest cliente)
        {
            var newCustomer = new Domain.Entities.Cliente.Request
            {
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                Email = cliente.Email
            };

            return _clienteRepository.Insert(newCustomer);
        }

        public IEnumerable<DTO.Cliente.Response> List()
        {
            var result = _clienteRepository.List().Select(s => new DTO.Cliente.Response
            {
                Id = s.Id,
                Nome = s.Nome,
                Email = s.Email,
                Cpf = s.Cpf
            }).ToList();

            return result;
        }

        public bool Update(DTO.Cliente.UpdateRequest cliente)
        {
            var newCustomer = new Domain.Entities.Cliente.Request
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                Email = cliente.Email
            };

            return _clienteRepository.Update(newCustomer);
        }
    }
}
