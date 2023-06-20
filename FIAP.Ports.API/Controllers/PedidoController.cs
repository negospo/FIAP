using FIAP.Modules.Application.DTO;
using FIAP.Modules.Application.UseCases;
using Microsoft.AspNetCore.Mvc;


namespace FIAP.Ports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoUseCase _pedidoUseCase;

        public PedidoController(IPedidoUseCase pedidoUseCase)
        {
            _pedidoUseCase = pedidoUseCase;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PedidoDto>> List()
        {
            return Ok(_pedidoUseCase.List());
        }

        [HttpGet("{id}")]
        public ActionResult<PedidoDto> Get(int id)
        {
            return _pedidoUseCase.Get(id);
        }

        [HttpPost]
        public ActionResult<PedidoDto> Post(CreatePedidoDto createPedidoDto)
        {
            return _pedidoUseCase.Save(createPedidoDto);
        }

        [HttpPut("{id}")]
        public void Put(int id, string value)
        {
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _pedidoUseCase.Delete(id);
            return NoContent(); 
        }
    }
}
