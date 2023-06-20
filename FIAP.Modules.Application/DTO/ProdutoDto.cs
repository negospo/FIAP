using FIAP.Modules.Domain.Enums;
using System;

namespace FIAP.Modules.Application.DTO
{
    public class ProdutoDto
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public ProdutoCategoria ProdutoCategoriaId { get; set; }
        public decimal Preco { get; set; }
    }
}
