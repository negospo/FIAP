namespace FIAP.Modules.Application.UseCases
{
    public interface IClienteUseCase
    {
        public DTO.Cliente.Response Get(int id);
        public IEnumerable<DTO.Cliente.Response> List();
        public bool Delete(int id);
        public bool Insert(DTO.Cliente.SaveRequest cliente);
        public bool Update(DTO.Cliente.UpdateRequest cliente);
        public DTO.Cliente.Response GetByCpf(string cpf);
        public bool Exists(DTO.Cliente.SaveRequest cliente);
        public bool Exists(DTO.Cliente.UpdateRequest cliente);
    }
}
