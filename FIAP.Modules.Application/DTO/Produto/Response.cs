﻿using FIAP.Modules.Domain.Enums;

namespace FIAP.Modules.Application.DTO.Produto
{
    public class Response
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public ProdutoCategoria ProdutoCategoriaId { get; set; }
        public decimal Preco { get; set; }
    }
}
