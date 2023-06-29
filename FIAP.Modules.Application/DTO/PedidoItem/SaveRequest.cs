using System.ComponentModel.DataAnnotations;

namespace FIAP.Modules.Application.DTO.PedidoItem
{
    public class SaveRequest
    {
        /// <summary>
        /// Id do produto
        /// </summary>
        [Required]
        public int? ProdutoId { get; set; }

        /// <summary>
        /// Quantidade do produto
        /// </summary>
        [Required]
        [Range(1,100)]
        public int? Quantidade { get; set; }
    }
}
