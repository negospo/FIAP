using FIAP.Modules.Application.DTO;
using FIAP.Modules.Application.UseCases;
using FIAP.Adapters.API.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace FIAP.Adapters.API.Controllers
{
    [ApiController]
    [Route("Pedido")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoUseCase _pedidoUseCase;


        public PedidoController(IPedidoUseCase pedidoUseCase, IClienteUseCase clienteUseCase)
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
        /// Cria um novo pedido. Deixe o ClienteId null ou 0 para fazer o pedido em modo anônimo.
        /// </summary>
        /// <param name="pedido">Dados do pedido</param>
        /// <response code="400" >Dados de cliente ou produtos inválidos</response>
        [HttpPost]
        [Route("order")]
        [CustonValidateModel]
        [ProducesResponseType(typeof(Validation.CustonValidationResultModel), 422)]
        public ActionResult<bool> CreateOrder(Modules.Application.DTO.Pedido.SaveRequest pedido)
        {
            try
            { 
                 var sucess = _pedidoUseCase.Order(pedido);
                 return Ok(sucess);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Altera o status de um pedido
        /// </summary>
        /// <param name="id">Id do pedido</param>
        /// <param name="status">Status do pedido</param>
        /// <response code="404" >Pedido não encontrado</response>
        [HttpPost]
        [Route("{id}/status/update")]
       
        public ActionResult<bool> UpdateOrderStatus(int id, Modules.Application.DTO.Pedido.UpdateOrderStatusRequest status)
        {
            var sucess = _pedidoUseCase.UpdateOrderStatus(id, status.Status);

            if (!sucess)
                return NotFound("Pedido não encontrado");
            else
                return Ok(sucess);
        }
    }
}
