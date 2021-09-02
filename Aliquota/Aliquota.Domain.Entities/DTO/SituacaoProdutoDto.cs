using Aliquota.Domain.Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Entities.DTO
{
    public class SituacaoProdutoDto
    {
        public int Id { get; set; }
        public string Situacao { get; set; }

        public SituacaoProdutoDto(SituacaoProduto situacaoProduto)
        {
            Id = situacaoProduto.Id;
            Situacao = situacaoProduto.Situacao;
        }
    }
}
