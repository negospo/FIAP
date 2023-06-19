using FIAP.Modules.Application.DTO;

namespace FIAP.Modules.Application.UseCases
{
    public interface IClienteUseCase
    {
        public DTO.ClienteDto GetClientePorCpf(string cpf);

        public ClienteDto Save(CreateClienteDto createClienteDto);

    }
}
