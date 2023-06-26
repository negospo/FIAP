using FIAP.Modules.Application.DTO;
using FIAP.Modules.Application.UseCases;
using FIAP.Adapters.API.Validation;
using Microsoft.AspNetCore.Mvc;


namespace FIAP.Adapters.API.Controllers
{
    [ApiController]
    [Route("Pedido")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoUseCase _pedidoUseCase;

        public PedidoController(IPedidoUseCase pedidoUseCase)
        {
            _pedidoUseCase = pedidoUseCase;
        }

        /// <summary>
        /// Lista todos os pedidos
        /// </summary>
        [HttpGet]
        [Route("list")]
        public ActionResult<IEnumerable<Modules.Application.DTO.Pedido.Response>> List()
        {
            return Ok(_pedidoUseCase.List());
        }

        /// <summary>
        /// Lista todos os pedidos de um status
        /// </summary>
        /// <param name="status">Status do pedido</param>
        [HttpGet]
        [Route("listbystatus")]
        public ActionResult<IEnumerable<Modules.Application.DTO.Pedido.Response>> ListByStatus(Modules.Domain.Enums.PedidoStatus status)
        {
            return Ok(_pedidoUseCase.ListByStatus(status));
        }

        /// <summary>
        /// Cria um novo pedido
        /// </summary>
        /// <param name="pedido">Dados do pedido</param>
        [HttpPost]
        [Route("order")]
        [CustonValidateModel]
        public ActionResult<bool> CreateOrder(Modules.Application.DTO.Pedido.SaveRequest pedido)
        {
            return Ok(_pedidoUseCase.Order(pedido));
        }

        /// <summary>
        /// Altera o status de um pedido
        /// </summary>
        /// <param name="id">Id do pedido</param>
        /// <param name="status">Status do pedido</param>
        [HttpPost]
        [Route("{id}/status/update")]
        public ActionResult<bool> UpdateOrderStatus(int id, Modules.Application.DTO.Pedido.UpdateOrderStatusRequest status)
        {
            return Ok(_pedidoUseCase.UpdateOrderStatus(id, status.Status));
        }
    }
}
