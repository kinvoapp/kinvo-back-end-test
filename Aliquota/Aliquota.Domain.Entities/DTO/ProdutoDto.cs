using Aliquota.Domain.Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Entities.DTO
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public int IdTipoProduto { get; set; }
        public int IdSituacaoProduto { get; set; }
        public int IdCliente { get; set; }
        public decimal? ValorInvestido { get; set; }
        public decimal? ValorAtual { get; set; }
        public decimal? ValorResgatado { get; set; }
        public DateTime DataInvestimento { get; set; }
        public DateTime? DataResgate { get; set; }
        public List<TipoProdutoDto> TipoProdutoList { get; set; }
        public SituacaoProdutoDto SituacaoAtual { get; set; }
        public ClienteDto Proprietario { get; set; }

        public ProdutoDto(Produto produto)
        {
            Id = produto.Id;
            IdTipoProduto = produto.IdTipoProduto;
            IdSituacaoProduto = produto.IdSituacaoProduto;
            IdCliente = produto.IdCliente;
            ValorInvestido = produto.ValorInvestido;
            ValorAtual = produto.ValorAtual;
            ValorResgatado = produto.ValorResgatado;
            DataInvestimento = produto.DataInvestimento;
            DataResgate = produto.DataResgate;
        }
    }
}
