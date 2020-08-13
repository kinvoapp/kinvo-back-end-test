using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestaAliquota
{
    public class ValidaRegrasDeNegocio
    {
        [Fact]
        public void TaxaIrAplicada()
        {
            //Arrange
            DateTime dataAplicacao = DateTime.Now;
            DateTime dataResgateAte1Ano = DateTime.Now.AddDays(363);//Até 1 ano de aplicação
            DateTime dataResgateEntre1e2anos = DateTime.Now.AddDays(672);//De 1 a 2 anos de aplicação
            DateTime dataResgateAcimaDe2Anos = DateTime.Now.AddDays(731);//Acima de 2 anos de aplicação

            var taxaIrResgateAte1Ano = Aliquota.Domain.Models.ProcessaDados.TaxaIRAplicadaTest(dataAplicacao, dataResgateAte1Ano);
            var taxaIrResgateEntre1e2anos = Aliquota.Domain.Models.ProcessaDados.TaxaIRAplicadaTest(dataAplicacao, dataResgateEntre1e2anos);
            var taxaIrResgateAcimaDe2Anos = Aliquota.Domain.Models.ProcessaDados.TaxaIRAplicadaTest(dataAplicacao, dataResgateAcimaDe2Anos);

            var taxaIrEsperadaParaResgateAte1Ano = "22,5%";
            var taxaIrEsperadaParaResgateEntre1e2anos = "18,5%";
            var taxaIrEsperadaParaResgateAcimaDe2Anos = "15%";

            //Assert
            Assert.Equal(taxaIrEsperadaParaResgateAte1Ano, taxaIrResgateAte1Ano);
            Assert.Equal(taxaIrEsperadaParaResgateEntre1e2anos, taxaIrResgateEntre1e2anos);
            Assert.Equal(taxaIrEsperadaParaResgateAcimaDe2Anos, taxaIrResgateAcimaDe2Anos);

        }
    }
}
