using Aliquota.Domain.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Entities.Entidades
{
    public class TipoProduto : IEntidade<int>
    {
        public virtual int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public virtual string Descricao { get => @"Entidade responsável por definir o tipo de produto a ser cadastrado";}
        public virtual int IdTipoProduto { get; set; }
        public virtual string NomeTipoProduto { get; set; }
        public virtual decimal Rentabilidade { get; set; }
    }
}
