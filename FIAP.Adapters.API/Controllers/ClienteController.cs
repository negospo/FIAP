using FIAP.Modules.Application.UseCases;
using FIAP.Adapters.API.Validation;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Adapters.API.Controllers
{
    [ApiController]
    [Route("Cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteUseCase _clienteUseCase;

        public ClienteController(IClienteUseCase clienteUseCase)
        {
            _clienteUseCase = clienteUseCase;
        }

        /// <summary>
        /// Retorna um cliente pelo seu id
        /// </summary>
        /// <param name="id">Id do cliente</param>
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Modules.Application.DTO.Cliente.Response> Get(int id)
        {
            return Ok(_clienteUseCase.Get(id));
        }

        /// <summary>
        /// Retorna um cliente pelo seu cpf
        /// </summary>
        /// <param name="cpf">Cpf do cliente</param>
        [HttpGet]
        [Route("getbycpf")]
        public ActionResult<Modules.Application.DTO.Cliente.Response> GetByCpf(string cpf)
        {
            return Ok(_clienteUseCase.GetByCpf(cpf));
        }

        /// <summary>
        /// Lista todos os clientes
        /// </summary>
        [HttpGet]
        [Route("list")]
        public ActionResult<IEnumerable<Modules.Application.DTO.Cliente.Response>> List()
        {
            return Ok(_clienteUseCase.List());
        }

        /// <summary>
        /// Verifica se um cliente ja existe
        /// </summary>
        [HttpPost]
        [Route("exists")]
        [CustonValidateModel]
        public ActionResult<bool> Exists(Modules.Application.DTO.Cliente.SaveRequest cliente)
        {
            return Ok(_clienteUseCase.Exists(cliente));
        }

        /// <summary>
        /// Exclui um cliente pelo seu id
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return Ok(_clienteUseCase.Delete(id));
        }

        /// <summary>
        /// Cria um novo cliente
        /// </summary>
        [HttpPost]
        [Route("create")]
        [CustonValidateModel]
        public ActionResult<bool> Create(Modules.Application.DTO.Cliente.SaveRequest cliente)
        {
            if (_clienteUseCase.Exists(cliente))
                return Conflict("Cliente já existe");

            return Ok(_clienteUseCase.Insert(cliente));
        }

        /// <summary>
        /// Altera um cliente
        /// </summary>
        [HttpPost]
        [Route("update")]
        [CustonValidateModel]
        public ActionResult<bool> Update(Modules.Application.DTO.Cliente.UpdateRequest cliente)
        {
            if (_clienteUseCase.Exists(cliente))
                return Conflict("Email ou CPF ja estão em uso");

            return Ok(_clienteUseCase.Update(cliente));
        }
    }
}
