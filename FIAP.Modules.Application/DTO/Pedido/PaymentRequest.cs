using System.ComponentModel.DataAnnotations;

namespace FIAP.Modules.Application.DTO.Pedido
{
    /// <summary>
    /// Dados de pagamento
    /// </summary>
    public class PaymentRequest
    {
        /// <summary>
        /// Tipo de pagamento
        /// </summary>
        [Required]
        public Modules.Domain.Enums.TipoPagamento? TipoPagamentoId { get; set; }

        /// <summary>
        /// Nome impresso no cartão de crédito
        /// </summary>
        [Required]
        [StringLength(50)]
        [MinLength(3)]
        public string Nome { get; set;}

        /// <summary>
        /// Token do cartão
        /// </summary>
        [Required]
        [StringLength(50)]
        [MinLength(3)]
        public string TokenCartao { get; set;}
    }
}
