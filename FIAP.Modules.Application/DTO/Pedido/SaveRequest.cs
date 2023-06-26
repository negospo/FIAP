using FIAP.Modules.Application.DTO.CustonDataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace FIAP.Modules.Application.DTO.Pedido
{
    public class SaveRequest
    {
        [RequiredIf("Anonimo",false,ErrorMessage = "ClienteId deve ser populado quando Anonimo for false")]
        public int? ClienteId { get; set; }
        [Required]
        public bool Anonimo { get; set; }
        public string ClienteObservacao { get; set; }
        [RequiredList]
        public IEnumerable<PedidoItem.SaveRequest> Itens { get; set; }
        public DTO.Pedido.PaymentRequest DadosPagamento { get; set; }
    }
}
