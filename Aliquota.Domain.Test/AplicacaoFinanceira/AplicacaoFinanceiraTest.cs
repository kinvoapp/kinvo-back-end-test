using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Aliquota.Domain.Entity;
using System.Reflection.Metadata;

namespace Aliquota.Domain.Test.AplicacaoFinanceira
{
    public class AplicacaoFinanceiraTest
    {
        public static readonly DateTime data = new DateTime(year: 2020, month: 1, day: 1);
        [Theory(DisplayName = "Checar Rendimento")]
        [Trait("Entity", "Aplicação Financeira")]
        [InlineData(1, 0.1, 11)]
        [InlineData(2, 0.3, 14)]
        [InlineData(1, 0.4, 10)]
        [InlineData(5, 0.1, 10)]
        [InlineData(16, 0.1, 10)]
        [InlineData(4, 0.07, 10)]
        [InlineData(3, 0.05, 10)]
        [InlineData(4, 0.05, 10)]
        public void AplicacaoFinanceira_GetRendimento_ReturnRendimento(decimal valor, decimal taxa, decimal esperado)
        {
            var aplicacao = new Entity.AplicacaoFinanceira()
            {
                DataAplicacao = data,
                Valor = valor,
                Produto = new ProdutoFinanceiro() { TaxaRedendimento = taxa }
            };
            var resultado = aplicacao.GetRendimento(DateTime.Now);

            Assert.Equal(esperado, resultado);
        }
    }
}
