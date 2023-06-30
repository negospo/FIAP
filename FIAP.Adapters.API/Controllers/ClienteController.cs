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
        /// <response code="404" >Cliente não encontrado</response>
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Modules.Application.DTO.Cliente.Response> Get(int id)
        {
            var customer = _clienteUseCase.Get(id);

            if (customer == null)
                return NotFound("Cliente não encontrado");
            else
                return Ok(customer);
        }

        /// <summary>
        /// Retorna um cliente pelo seu cpf
        /// </summary>
        /// <param name="cpf">Cpf do cliente</param>
        /// <response code="404" >Cliente não encontrado</response>
        [HttpGet]
        [Route("getbycpf")]
        public ActionResult<Modules.Application.DTO.Cliente.Response> GetByCpf(string cpf)
        {
            var customer = _clienteUseCase.GetByCpf(cpf);

             if (customer == null)
                return NotFound("Cliente não encontrado");
            else
                return Ok(customer);
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
        /// <response code="404" >Cliente não encontrado</response>
        [HttpDelete]
        [Route("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var sucess = _clienteUseCase.Delete(id);

            if (!sucess)
                return NotFound("Cliente não encontrado");
            else
                return Ok(sucess);
        }

        /// <summary>
        /// Cria um novo cliente
        /// </summary>
        /// <response code="409" >Email ou CPF ja estão em uso</response>
        [HttpPost]
        [Route("create")]
        [CustonValidateModel]
        [ProducesResponseType(typeof(Validation.CustonValidationResultModel), 422)]
        public ActionResult<bool> Create(Modules.Application.DTO.Cliente.SaveRequest cliente)
        {
            if (_clienteUseCase.Exists(cliente))
                return Conflict("Cliente já existe");

            return Ok(_clienteUseCase.Insert(cliente));
        }

        /// <summary>
        /// Altera um cliente
        /// </summary>
        /// <response code="404" >Cliente não encontrado</response>
        /// <response code="409" >Email ou CPF ja estão em uso</response>
        [HttpPost]
        [Route("update")]
        [CustonValidateModel]
        [ProducesResponseType(typeof(Validation.CustonValidationResultModel), 422)]
        public ActionResult<bool> Update(Modules.Application.DTO.Cliente.UpdateRequest cliente)
        {
            if (_clienteUseCase.Exists(cliente))
                return Conflict("Email ou CPF ja estão em uso");

            var sucess = _clienteUseCase.Update(cliente);

            if (!sucess)
                return NotFound("Cliente não encontrado");
            else
                return Ok(sucess);
        }
    }
}
