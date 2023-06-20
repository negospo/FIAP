using FIAP.Modules.Application.DTO;
using FIAP.Modules.Application.UseCases;
using FIAP.Modules.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Ports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private readonly ILogger<ProdutoController> _logger;
        private readonly IProdutoUseCase _produtoUseCase;

        public ProdutoController(ILogger<ProdutoController> logger, IProdutoUseCase produtoUseCase)
        {
            _logger = logger;
            _produtoUseCase = produtoUseCase;
        }
        [HttpGet]
        public ActionResult<ICollection<ProdutoDto>> GetByCategoria(ProdutoCategoria produtoCategoria)
        {
            return Ok(_produtoUseCase.GetByCategoria(produtoCategoria));
        }

        [HttpGet("{id}")] 
        public ActionResult<ProdutoDto> Get(int id)
        {
            return _produtoUseCase.Get(id);
        }

        [HttpPost]
        public ActionResult<ProdutoDto> Save(ProdutoDto produtoDto)
        {
            return _produtoUseCase.Save(produtoDto);
        }

        //To do: Implementar delete method
        [HttpDelete]
        public ActionResult Delete(int id) 
        {
            _produtoUseCase.Delete(id);
            return NoContent();
        }
    }
}
