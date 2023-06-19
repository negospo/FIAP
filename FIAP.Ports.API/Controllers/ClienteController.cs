using FIAP.Modules.Application.DTO;
using FIAP.Modules.Application.UseCases;
using Microsoft.AspNetCore.Mvc;


namespace FIAP.Ports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteUseCase _clienteUseCase;

        public ClienteController(IClienteUseCase clienteUseCase)
        {
            _clienteUseCase = clienteUseCase;
        }

        [HttpGet("{cpf}")]
        public ActionResult<ClienteDto> GetClientPorCpf(string cpf)
        {
            return Ok(_clienteUseCase.GetClientePorCpf(cpf));
        }

        [HttpPost]
        public IActionResult CreateCliente([FromBody] ClienteDto clienteDto)
        {
            throw new NotImplementedException();
        }

    }
}
