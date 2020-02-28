using Aliquota.Domain.Domain.AgregadoProduto;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Aliquota.Domain.Test.Domain
{
    public class ResgateTest
    {
        [Fact]
        public void GerarResgateComSucesso()
        {
            var data = DateTime.Now;
            var valorResgate = 1500.00M;
            var produto = Produto.Create("Teste", new DateTime(2019, 01, 05), 200.00M, 7.00M, 1500.00M);
            var resgate = produto.ResgatarRendimentos(valorResgate, data);

            Assert.True(resgate.Valor == valorResgate);
            Assert.True(resgate.Data == data);
            
        }
    }
}
