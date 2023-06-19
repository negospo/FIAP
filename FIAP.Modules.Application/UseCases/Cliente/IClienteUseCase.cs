using FIAP.Modules.Domain.Entities;

namespace FIAP.Modules.Application.UseCases
{
    public interface IClienteUseCase
    {
        public DTO.ClienteDto GetClientePorCpf(string cpf);

        public bool Save(DTO.ClienteDto clienteDto);

    }
}
