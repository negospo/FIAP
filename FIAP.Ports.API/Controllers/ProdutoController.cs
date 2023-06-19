using Microsoft.AspNetCore.Mvc;

namespace FIAP.Ports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private readonly ILogger<ProdutoController> _logger;
        public ProdutoController(ILogger<ProdutoController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [Route("get")]
        public async Task<Modules.Application.DTO.ProdutoDto> Get()
        {
            return new Modules.Application.DTO.ProdutoDto();
        }

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult<bool>> Save(Modules.Application.DTO.ProdutoDto model)
        {
            return true;
        }

    }
}
