using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System;

namespace FIAP.Ports.API.Controllers
{
    [Route("[controller]")]
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
        public async Task<Modules.Application.DTO.Produto> Get()
        {
            return new Modules.Application.DTO.Produto();
        }

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult<bool>> Save(Modules.Application.DTO.Produto model)
        {
            return true;
        }

    }
}
