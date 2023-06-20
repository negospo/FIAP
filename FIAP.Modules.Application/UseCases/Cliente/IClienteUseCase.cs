using FIAP.Modules.Application.DTO;

namespace FIAP.Modules.Application.UseCases
{
    public interface IClienteUseCase
    {
        public DTO.Cliente.Response Get(int id);
        public IEnumerable<DTO.Cliente.Response> List();
        public bool Delete(int id);
        public bool Insert(DTO.Cliente.Request cliente);
        public bool Update(DTO.Cliente.Request cliente);
        public DTO.Cliente.Response GetByCpf(string cpf);
        public bool Exists(DTO.Cliente.Request cliente);
    }
}
