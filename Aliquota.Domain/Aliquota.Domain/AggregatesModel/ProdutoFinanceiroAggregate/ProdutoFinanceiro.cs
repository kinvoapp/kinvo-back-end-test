using Aliquota.Domain.SeedWork;
using System;

namespace Aliquota.Domain.AggregatesModel.ProdutoFinanceiroAggregate
{
    public class ProdutoFinanceiro : Entity, IAggregateRoot
    {
        public string descricao { get; private set; }
        public double taxaDeRendimento { get; private set; }

        public ProdutoFinanceiro(string descricao, double taxaDeRendimento)
        {
            this.descricao = descricao;
            if (taxaDeRendimento <= 0)
                throw new Exception("O valor da taxa de rendimento está inválido. A taxa de rendimento não pode ser menor ou igual a zero.");
            this.taxaDeRendimento = taxaDeRendimento;
        }
    }
}
