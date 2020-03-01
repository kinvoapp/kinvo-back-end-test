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

            //Ação
            var resultadoAtual = TestResgate.Resgate(DateTime.Now.AddMonths(6));

            //Afirmação

            Assert.Equal(resultadoEsperado, resultadoAtual);

        }
        [Fact]
        public void Aplicar_ValorAplicadoMaiorQueZero_True()
        {
            //Organizar
            ProdutoFinanceiro TestPessoa = new ProdutoFinanceiro();

            //Ação
            bool resultadoAtual = TestPessoa.Aplicar(1000, DateTime.Now);
            //Afirmação
            Assert.True(resultadoAtual, "Valor aplicado é válido");
        }
        [Fact]
        public void CalculoIR_ValoresCalculadosSatisfeitos_CalculosCorretos()
        {
            //Organizar
            //Inicializa um objeto com DataAplicação que será relevante nos testes
            ProdutoFinanceiro TestIR = new ProdutoFinanceiro(1, DateTime.Now);

            //Lucro a ser calculado em todos será de 2000 o que mudará serão os anos
            double[] resultadoEsperado = new double[3];
            resultadoEsperado[0] = 450; //22,5% de IR
            resultadoEsperado[1] = 370; //18,5% de IR
            resultadoEsperado[2] = 300; //15% de IR

            //Ação

            //Afirmação
            Assert.Equal(resultadoEsperado[0], TestIR.CalculoIR(2000, DateTime.Now.AddMonths(6)));//5meses Add é N-1 | Valores em meses uma vez que é necessário ser até 1 ano
            Assert.Equal(resultadoEsperado[1], TestIR.CalculoIR(2000, DateTime.Now.AddYears(2)));//1 e 2 atendem esse
            Assert.Equal(resultadoEsperado[2], TestIR.CalculoIR(2000, DateTime.Now.AddYears(3)));//qualquer valor acima de 2 atendem esse

        }
    }
}
