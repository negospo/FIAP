﻿using FIAP.Modules.Application.DTO;
using FIAP.Modules.Application.UseCases;
using Microsoft.AspNetCore.Mvc;


namespace FIAP.Ports.API.Controllers
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

        [HttpGet]
        [Route("list")]
        public ActionResult<IEnumerable<Modules.Application.DTO.Pedido.Response>> List()
        {
            return Ok(_pedidoUseCase.List());
        }

        [HttpGet]
        [Route("listbystatus")]
        public ActionResult<IEnumerable<Modules.Application.DTO.Pedido.Response>> ListByStatus(Modules.Domain.Enums.PedidoStatus status)
        {
            return Ok(_pedidoUseCase.ListByStatus(status));
        }

        [HttpPost]
        [Route("order")]
        public ActionResult<bool> CreateOrder(Modules.Application.DTO.Pedido.SaveRequest pedido)
        {
            return Ok(_pedidoUseCase.Order(pedido));
        }


        [HttpPost]
        [Route("{id}/status/update")]
        public ActionResult<bool> UpdateOrderStatus(int id, Modules.Application.DTO.Pedido.UpdateOrderStatusRequest status)
        {
            return Ok(_pedidoUseCase.UpdateOrderStatus(id, status.Status));
        }
    }
}
