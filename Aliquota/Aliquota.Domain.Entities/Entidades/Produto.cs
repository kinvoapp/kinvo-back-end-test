using Aliquota.Domain.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Entities.Entidades
{
    public class Produto : IEntidade<int>
    {
        public virtual int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public virtual string Descricao { get => @"Entidade responsável por manter o produto de determinado cliente"; }
        public virtual int IdProduto { get; set; }
        public virtual int IdTipoProduto { get; set; }
        public virtual int IdSituacaoProduto { get; set; }
        public virtual int IdCliente { get; set; }
        public virtual decimal? ValorInvestido { get; set; }
        public virtual decimal? ValorAtual { get; set; }
        public virtual decimal? ValorResgatado { get; set; }
        public virtual DateTime DataInvestimento { get; set; }
        public virtual DateTime? DataResgate { get; set; }
        public virtual TipoProduto TipoProduto { get; set; }
        public virtual SituacaoProduto SituacaoProduto { get; set; }
        public virtual Cliente Cliente { get; set; }

    }
}
