using Repository.Aliquiota;
using System;
using Xunit;

namespace Aliquiota.Domain.Test
{
    public class TestRepository
    {
        InvestimentoDAO _investimentoDAO = new InvestimentoDAO();
        ContaDAO _contaDAO;
        ProdutoDAO _produtoDAO;
       

        [Fact]
        public void TestDiferencaDatas()
        {


            var data1 = DateTime.Now;
            var data2 = DateTime.Now.AddDays(370);

            int[] valores = _investimentoDAO.CalculaDatas(data1, data2);

            Assert.Equal( 1 ,valores[1]);
        }
    }
}
