using System.ComponentModel.DataAnnotations;

namespace FIAP.Modules.Application.DTO.PedidoItem
{
    public class SaveRequest
    {
        [Required]
        public int? ProdutoId { get; set; }
        [Required]
        public int? Quantidade { get; set; }
    }
}
