using FIAP.Modules.Application.DTO;

namespace FIAP.Modules.Application.UseCases
{
    public interface IClienteUseCase
    {
        public ClienteDto GetClientePorCpf(string cpf);

        public ClienteDto Save(CreateClienteDto createClienteDto);

    }
}
