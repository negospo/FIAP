using System.ComponentModel.DataAnnotations;

namespace FIAP.Modules.Application.DTO.Cliente
{
    public class SaveRequest
    {
        [Required]
        [StringLength(150)]
        [MinLength(3)]
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(11)]
        [MinLength(11)]
        public string Cpf { get; set; }
    }
}
