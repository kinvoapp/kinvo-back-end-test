using System;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class ProdutoFinanceiroTest
    {

        //[metodo]_[condicao]_[resultadoesperado]
        [Fact]
        public void Resgate_dataResgateMaiorDataAplicacao_LucroComDiferencaCalculadaDoIR()
        {
            //Organizar
            ProdutoFinanceiro TestResgate = new ProdutoFinanceiro(1000, DateTime.Now);
            TestResgate.LucroAdd(2000);

            //Calculo: Lucro - Lucro*IR (6 meses para o resgate)
            var resultadoEsperado = 1550;  //2000 - 2000 * 0.225(IR aplicado entre 0 e 1 ano) 

            //A��o
            var resultadoAtual = TestResgate.Resgate(DateTime.Now.AddMonths(6));

            //Afirma��o

            Assert.Equal(resultadoEsperado, resultadoAtual);

        }
        [Fact]
        public void Aplicar_ValorAplicadoMaiorQueZero_True()
        {
            //Organizar
            ProdutoFinanceiro TestPessoa = new ProdutoFinanceiro();

            //A��o
            bool resultadoAtual = TestPessoa.Aplicar(1000, DateTime.Now);
            //Afirma��o
            Assert.True(resultadoAtual, "Valor aplicado � v�lido");
        }
        [Fact]
        public void CalculoIR_ValoresCalculadosSatisfeitos_CalculosCorretos()
        {
            //Organizar
            //Inicializa um objeto com DataAplica��o que ser� relevante nos testes
            ProdutoFinanceiro TestIR = new ProdutoFinanceiro(1, DateTime.Now);

            //Lucro a ser calculado em todos ser� de 2000 o que mudar� ser�o os anos
            double[] resultadoEsperado = new double[3];
            resultadoEsperado[0] = 450; //22,5% de IR
            resultadoEsperado[1] = 370; //18,5% de IR
            resultadoEsperado[2] = 300; //15% de IR

            //A��o

            //Afirma��o
            Assert.Equal(resultadoEsperado[0], TestIR.CalculoIR(2000, DateTime.Now.AddMonths(6)));//5meses Add � N-1 | Valores em meses uma vez que � necess�rio ser at� 1 ano
            Assert.Equal(resultadoEsperado[1], TestIR.CalculoIR(2000, DateTime.Now.AddYears(2)));//1 e 2 atendem esse
            Assert.Equal(resultadoEsperado[2], TestIR.CalculoIR(2000, DateTime.Now.AddYears(3)));//qualquer valor acima de 2 atendem esse

        }
    }
}
