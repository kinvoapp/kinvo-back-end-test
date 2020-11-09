using Aliquota.Domain.Entities;
using System;

namespace Aliquota.Infraestructure.Test.Builders
{
    public class AplicacaoFinanceiraBuilder
    {
        private AplicacaoFinanceira aplicacao;
        public AplicacaoFinanceira CriarAplicacaoFinanceira()
        {
            aplicacao = new AplicacaoFinanceira()
            {
                Nome = "Tesouro SELIC",
                ValorAplicado = 1000,
                TaxaRendimento = 2,
                DataAplicacao = DateTime.Now.AddDays(-90)
            };
            return aplicacao;
        }
    }
}
