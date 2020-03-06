using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain
{
    public class ProdutoFinanceiro
    {
        private int tempoTotal;
        private float lucroTotal, taxaRendimento, valorInvestidoAtual, valorRecolhidoIR;
        private DateTime dataAplicacao, dataResgate1, dataResgate2;

        public ProdutoFinanceiro() { }

        public ProdutoFinanceiro(float taxaRendimento)
        {
            tempoTotal = 0;
            lucroTotal = 0;
            this.taxaRendimento = taxaRendimento;
        }

        #region Getters and Setters
        public int TempoTotal { get { return tempoTotal; } set { tempoTotal = value; } }

        public float LucroTotal { get { return lucroTotal; } set { lucroTotal = value; } }

        public float TaxaRendimento { get { return taxaRendimento; } set { taxaRendimento = value; } }

        public float ValorInvestidoAtual { get { return valorInvestidoAtual; } set { valorInvestidoAtual = value; } }

        public float ValorRecolhidoIR { get { return valorRecolhidoIR; } set { valorRecolhidoIR = value; } }

        public DateTime DataAplicacao { get { return dataAplicacao; } set { dataAplicacao = value; } }

        public DateTime DataResgate1 { get { return dataResgate1; } set { dataResgate1 = value; } }

        public DateTime DataResgate2 { get { return dataResgate2; } set { dataResgate2 = value; } }

        #endregion

        public void aplicarMontante(float valorAplicado)
        {
            if (valorAplicado > 0)
            {
                ValorInvestidoAtual += valorAplicado;
            }

            else throw new NotImplementedException("Valor para aplicação inválido.");
        }

        public float calcularLucro(int tempoDecorridoUltimoResgate)
        {
            //Não foi informada a taxa de rendimento do produto financeiro, então atribuí um valor arbitrário para o cálculo do lucro
            float lucro;
            lucro = tempoDecorridoUltimoResgate * TaxaRendimento * ValorInvestidoAtual;
            LucroTotal += lucro;
            ValorInvestidoAtual += lucro; //Atualiza o valor investido
            return LucroTotal;
        }

        public void resgatarMontante(float valorResgatado)
        {
            if ((valorResgatado == 0) ^ (valorResgatado > ValorInvestidoAtual))
                throw new NotImplementedException("Valor para resgate inválido.");

            else
            {
                ValorInvestidoAtual -= valorResgatado;

                if (ValorInvestidoAtual == 0)
                {
                    calcularImpostoDeRenda();
                }
            }
        }

        public int calcularTempo(DateTime dataInicial = new DateTime(), DateTime dataFinal = new DateTime())
        {
            if (dataFinal > dataInicial)
                return ((dataFinal.Year - dataInicial.Year) * 12) + dataFinal.Month - dataInicial.Month;

            else return 0;
        }

        public void calcularImpostoDeRenda()
        {
            //Cálculo do valor recolhido como IR
            int tempoDecorrido = calcularTempo(DataAplicacao, DataResgate2);

            if (tempoDecorrido < 12)
            {
                ValorRecolhidoIR = 0.225f * LucroTotal;
            }

            else if (tempoDecorrido >= 12 && tempoDecorrido <= 24)
            {
                ValorRecolhidoIR = 0.185f * LucroTotal;
            }

            else if (tempoDecorrido > 24)
            {
                ValorRecolhidoIR = 0.15f * LucroTotal;
            }
        }

        public float calcularValorResgatado(List<float> valorResgatado)
        {
            float valorTotalResgatado = 0;

            foreach (float value in valorResgatado)
            {
                valorTotalResgatado += value;
            }

            return valorTotalResgatado;
        }
    }
}
