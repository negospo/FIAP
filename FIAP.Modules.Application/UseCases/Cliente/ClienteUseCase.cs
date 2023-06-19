using FIAP.Modules.Application.DTO;
using FIAP.Modules.Domain.Entities;
using FIAP.Modules.Domain.Repositories;

namespace FIAP.Modules.Application.UseCases
{
    public class ClienteUseCase : IClienteUseCase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteUseCase(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public ClienteDto GetClientePorCpf(string cpf)
        {
            var cliente = _clienteRepository.GetByCpf(cpf);

            var clienteDto = new ClienteDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                Email = cliente.Email,
            };
            return clienteDto;
        }

        public bool Save(ClienteDto clienteDto)
        {
            throw new NotImplementedException();
        }
    }
}
