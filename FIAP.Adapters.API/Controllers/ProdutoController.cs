using FIAP.Modules.Application.DTO;
using FIAP.Modules.Application.UseCases;
using FIAP.Modules.Domain.Enums;
using FIAP.Adapters.API.Validation;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Adapters.API.Controllers
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

        /// <summary>
        /// Retorna um produto pelo id
        /// </summary>
        /// <param name="id">Id do produto</param>
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Modules.Application.DTO.Produto.Response> Get(int id)
        {
            return Ok(_produtoUseCase.Get(id));
        }

        /// <summary>
        /// Retorna todos os produtos
        /// </summary>
        [HttpGet]
        [Route("list")]
        public ActionResult<IEnumerable<Modules.Application.DTO.Produto.Response>> List()
        {
            return Ok(_produtoUseCase.List());
        }

        /// <summary>
        /// Retorna todos os produtos de uma categoria
        /// </summary>
        /// <param name="categoria">Categoria do produto</param>
        [HttpGet]
        [Route("listbycategory")]
        public ActionResult<IEnumerable<Modules.Application.DTO.Produto.Response>> ListByCategory(Modules.Domain.Enums.ProdutoCategoria categoria)
        {
            return Ok(_produtoUseCase.ListByCategory(categoria));
        }

        /// <summary>
        /// Exclui um produto pelo id
        /// </summary>
        /// <param name="id">Id do produdo</param>
        [HttpDelete]
        [Route("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return Ok(_produtoUseCase.Delete(id));
        }

        /// <summary>
        /// Cria um novo produto
        /// </summary>
        /// <param name="produto">Dados do produto</param>
        [HttpPost]
        [Route("create")]
        [CustonValidateModel]
        public ActionResult<bool> Create(Modules.Application.DTO.Produto.SaveRequest produto)
        {
            return Ok(_produtoUseCase.Insert(produto));
        }

        /// <summary>
        /// Altera um produto
        /// </summary>
        /// <param name="produto">Dados do produdo</param>
        [HttpPost]
        [Route("update")]
        [CustonValidateModel]
        public ActionResult<bool> Update(Modules.Application.DTO.Produto.UpdateRequest produto)
        {
            return Ok(_produtoUseCase.Update(produto));
        }

    }
}
