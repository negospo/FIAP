using System.ComponentModel.DataAnnotations;

namespace FIAP.Modules.Application.DTO.Pedido
{
    public class PaymentRequest
    {
        [Required]
        public Modules.Domain.Enums.TipoPagamento? TipoPagamentoId { get; set; }

        [Required]
        [StringLength(50)]
        [MinLength(3)]
        public string Nome { get; set;}


        [Required]
        [StringLength(50)]
        [MinLength(3)]
        public string TokenCartao { get; set;}
    }
}
