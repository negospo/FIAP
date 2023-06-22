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

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Modules.Application.DTO.Cliente.Response> Get(int id)
        {
            return Ok(_clienteUseCase.Get(id));
        }

        [HttpGet]
        [Route("getbycpf")]
        public ActionResult<Modules.Application.DTO.Cliente.Response> GetByCpf(string cpf)
        {
            return Ok(_clienteUseCase.GetByCpf(cpf));
        }

        [HttpGet]
        [Route("list")]
        public ActionResult<IEnumerable<Modules.Application.DTO.Cliente.Response>> List()
        {
            return Ok(_clienteUseCase.List());
        }

        [HttpPost]
        [Route("exists")]
        [CustonValidateModel]
        public ActionResult<bool> Exists(Modules.Application.DTO.Cliente.SaveRequest cliente)
        {
            return Ok(_clienteUseCase.Exists(cliente));
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return Ok(_clienteUseCase.Delete(id));
        }

        [HttpPost]
        [Route("create")]
        [CustonValidateModel]
        public ActionResult<bool> Create(Modules.Application.DTO.Cliente.SaveRequest cliente)
        {
            if (_clienteUseCase.Exists(cliente))
                return Conflict("Cliente já existe");

            return Ok(_clienteUseCase.Insert(cliente));
        }

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
