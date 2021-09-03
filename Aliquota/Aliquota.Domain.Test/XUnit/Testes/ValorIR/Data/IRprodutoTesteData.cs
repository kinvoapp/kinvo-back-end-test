using Aliquota.Domain.Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Aliquota.Domain.Test.XUnit.Testes.ValorIR.Data
{
    public class IRprodutoTesteData : TheoryData<Produto, decimal>
    {
        public IRprodutoTesteData()
        {
            TesteMenor1Ano();
            TesteMaior1Menor2Anos();
            TesteMaior2Anos();
        }

        private void TesteMenor1Ano()
        {
            var produto = new Produto();
            produto.DataInvestimento = new DateTime(2020,01,01);
            produto.DataResgate = new DateTime(2020, 12, 01);
            produto.ValorInvestido = 1000m;
            produto.ValorAtual = 15000m;
            Add(produto, 3150m);
        }

        private void TesteMaior1Menor2Anos()
        {

            var produto = new Produto();
            produto.DataInvestimento = new DateTime(2020, 01, 01);
            produto.DataResgate = new DateTime(2021, 12, 01);
            produto.ValorInvestido = 1000m;
            produto.ValorAtual = 15000m;
            Add(produto, 2590m);
        }

        private void TesteMaior2Anos()
        {
            var produto = new Produto();
            produto.DataInvestimento = new DateTime(2020, 01, 01);
            produto.DataResgate = new DateTime(2025, 12, 01);
            produto.ValorInvestido = 1000m;
            produto.ValorAtual = 15000m;
            Add(produto, 2100m);
        }
    }
}
