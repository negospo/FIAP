using FIAP.Modules.Application.DTO.CustonDataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace FIAP.Modules.Application.DTO.Pedido
{
    public class SaveRequest
    {
        /// <summary>
        /// Id do cliente. Deixar null caso queira que o pedido seja feito em modo anônimo
        /// </summary>
        public int? ClienteId { get; set; }
        /// <summary>
        /// Observação do cliente
        /// </summary>
        public string ClienteObservacao { get; set; }

        /// <summary>
        /// Itens do pedido
        /// </summary>
        [RequiredList]
        public IEnumerable<PedidoItem.SaveRequest> Itens { get; set; }

        /// <summary>
        /// Dados do pagamento
        /// </summary>
        [Required]
        public DTO.Pedido.PaymentRequest DadosPagamento { get; set; }
    }
}
