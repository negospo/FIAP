﻿namespace FIAP.Modules.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Enums.ProdutoCategoria ProdutoCategoriaId { get; set; }
        public decimal Preco { get; set; }
    }
}