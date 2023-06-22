using System.ComponentModel.DataAnnotations;

namespace FIAP.Modules.Application.DTO.Pedido
{
    public class UpdateOrderStatusRequest
    {
        [Required]
        public Domain.Enums.PedidoStatus Status { get; set; }
    }
}
