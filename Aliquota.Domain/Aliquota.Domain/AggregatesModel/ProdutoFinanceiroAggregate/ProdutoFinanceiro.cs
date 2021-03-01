using System;
using System.Collections.Generic;
using System.Text;
using Aliquota.Domain.SeedWork;


namespace Aliquota.Domain.AggregatesModel.ProdutoFinanceiroAggregate
{
    public class ProdutoFinanceiro : Entity, IAggregateRoot
    {
        public string descricao { get; private set; }
        public double taxaDeRendimento { get; private set; }

        public ProdutoFinanceiro (string descricao, double taxaDeRendimento)
        {            
            this.descricao = descricao;
            this.taxaDeRendimento = taxaDeRendimento;
        }
    }
}
