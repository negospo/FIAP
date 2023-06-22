using FIAP.Modules.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FIAP.Modules.Application.DTO.Produto
{
    public class SaveRequest
    {
        [Required]
        [StringLength(100)]
        [MinLength(3)]
        public string Nome { get; set; }
        [Required]
        [StringLength(500)]
        [MinLength(3)]
        public string Descricao { get; set; }

        public string Imagem { get; set; }
        
        [Required]
        public ProdutoCategoria ProdutoCategoriaId { get; set; }
        [Required]
        public decimal? Preco { get; set; }
    }
}
