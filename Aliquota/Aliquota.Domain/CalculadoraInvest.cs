using Aliquota.Domain.Models;
using System;

namespace Aliquota.Domain
{
    public static class CalculadoraInvest
    {
        public static int DiasEntreDatas(DateTime dataInicial, DateTime dataFinal)
        {
            VerificaDatas(dataInicial, dataFinal);

            return ((int)(dataFinal - dataInicial).TotalDays);
        }

        public static int MesesEntreDatas(DateTime dataInicial, DateTime dataFinal)
        {
            VerificaDatas(dataInicial, dataFinal);

            return ((dataFinal.Year - dataInicial.Year) * 12)
                   + (dataFinal.Month - dataInicial.Month)
                   + (dataFinal.Day >= dataInicial.Day ? 0 : -1);
        }

        private static void VerificaDatas(DateTime dataInicial, DateTime dataFinal)
        {
            if (dataInicial > dataFinal)
            {
                var msg = $"{nameof(dataFinal)} precisa ser maior ou igual a {nameof(dataInicial)}";
                throw new ArgumentException(msg, nameof(dataFinal));
            }
        }

        public static double RendimentoDoInvestimento(Investimento investimento, DateTime dataResgate)
        {
            var totalDiasCapitalInvestido = (int)(dataResgate - investimento.DataInvestimento).TotalDays;

            if (totalDiasCapitalInvestido < 0)
            {
                var msg = $"A data de resgate não pode ser menor que a data de investimento";
                throw new ArgumentOutOfRangeException(nameof(dataResgate), msg);
            }

            var capitalInicial = investimento.ValorInvestido;
            var taxaRendimentoDia = investimento.Produto.TaxaRendimentoAnual;

            var montanteFinal = RendimentoDoInvestimento(capitalInicial, taxaRendimentoDia, totalDiasCapitalInvestido);
            
            return montanteFinal;
        }

        public static double RendimentoDoInvestimento(double capitalInvestido, double taxaAoAno, int totalDiasCapitalInvestido)
        {
            #region Check Argumento
            if (capitalInvestido <= 0)
            {
                var msg = $"O capital inicial não pode ser menor ou igual a ZERO";
                throw new ArgumentOutOfRangeException(nameof(capitalInvestido), msg);
            }

            if (taxaAoAno < 0)
            {
                var msg = $"A taxa de rendimento anual não pode ser negativa";
                throw new ArgumentOutOfRangeException(nameof(taxaAoAno), msg);
            }

            if (totalDiasCapitalInvestido < 0)
            {
                var msg = $"O período do investimento não pode ser negativo";
                throw new ArgumentOutOfRangeException(nameof(totalDiasCapitalInvestido), msg);
            }

            #endregion

            double taxaAoDia = GetTaxaAoDia(taxaAoAno);

            return JurosCompostos(capitalInvestido, taxaAoDia, totalDiasCapitalInvestido);
        }

        private static double GetTaxaAoDia(double taxaAoAno) => (double)(taxaAoAno / 100) / 365;

        private static double JurosCompostos(double capital, double taxaDia, int tempo)
        {
            /*  M = C.(1+i)^t
                
                M: Montante final
                C: Capital inicial (investido)
                i: Taxa de rendimento
                t: Tempo do investimento
            */

            var taxa = (double)(1 + taxaDia);
            var montante = capital * Math.Pow(taxa, tempo);

            // Arredondamento de casas
            return Math.Round(montante, 2, MidpointRounding.AwayFromZero);
        }
    
        public static double ImpostoDeRendaSobreLucro(double valorRendimento, int mesesInvestido)
        {
            if (mesesInvestido < 0)
            {
                var msg = $"O parâmetro {nameof(mesesInvestido)} não pode ser negativo";
                throw new ArgumentOutOfRangeException(nameof(mesesInvestido), msg);
            }

            if (valorRendimento == 0)
                return 0;

            var taxaTributacao = ValorTributacao(mesesInvestido);

            var imposto = valorRendimento * taxaTributacao;

            return Math.Round(imposto, 2, MidpointRounding.AwayFromZero);
        }

        public static double ValorTributacao(int periodoMeses)
        {
            if (periodoMeses <= 12)
                return 0.225;

            if (periodoMeses <= 24)
                return 0.185;

            return 0.15;
        }
    
    }
}
