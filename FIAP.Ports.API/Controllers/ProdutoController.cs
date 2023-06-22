using FIAP.Modules.Application.DTO;
using FIAP.Modules.Application.UseCases;
using FIAP.Modules.Domain.Enums;
using FIAP.Ports.API.Validation;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Ports.API.Controllers
{
    [ApiController]
    [Route("Produto")]
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
        [Route("{id}")]
        public ActionResult<Modules.Application.DTO.Produto.Response> Get(int id)
        {
            return Ok(_produtoUseCase.Get(id));
        }

        [HttpGet]
        [Route("list")]
        public ActionResult<IEnumerable<Modules.Application.DTO.Produto.Response>> List()
        {
            return Ok(_produtoUseCase.List());
        }

        [HttpGet]
        [Route("listbycategory")]
        public ActionResult<IEnumerable<Modules.Application.DTO.Produto.Response>> ListByCategory(Modules.Domain.Enums.ProdutoCategoria categoria)
        {
            return Ok(_produtoUseCase.ListByCategory(categoria));
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return Ok(_produtoUseCase.Delete(id));
        }


        [HttpPost]
        [Route("create")]
        [CustonValidateModel]
        public ActionResult<bool> Create(Modules.Application.DTO.Produto.SaveRequest produto)
        {
            return Ok(_produtoUseCase.Insert(produto));
        }

        [HttpPost]
        [Route("update")]
        [CustonValidateModel]
        public ActionResult<bool> Update(Modules.Application.DTO.Produto.UpdateRequest produto)
        {
            return Ok(_produtoUseCase.Update(produto));
        }

    }
}
