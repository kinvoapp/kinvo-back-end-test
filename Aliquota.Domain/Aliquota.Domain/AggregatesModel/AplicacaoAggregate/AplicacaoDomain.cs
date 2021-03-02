using System;

namespace Aliquota.Domain.AggregatesModel.AplicacaoAggregate
{
    public class AplicacaoDomain
    {
        private readonly Aplicacao aplicacao;

        public AplicacaoDomain(Aplicacao aplicacao)
        {
            this.aplicacao = aplicacao;
        }

        public double CalcularValorAResgatar(double taxaDeRendimento, DateTime dataDoResgate)
        {
            if (dataDoResgate < aplicacao.dataInicial)
                throw new Exception("A data de resgate da aplicação é invalida. A data de resgate não pode ser anterior a data inicial da aplicação.");
            int mesesDaAplicacao = calculaDuracaoDaAplicacaoEmMeses(aplicacao.dataInicial, dataDoResgate);
            double taxaAliquota;
            double lucro;

            switch (mesesDaAplicacao)
            {
                case var duracao when mesesDaAplicacao < 12 && mesesDaAplicacao >= 0:
                    taxaAliquota = 0.225;
                    break;
                case var duracao when mesesDaAplicacao >= 12 && mesesDaAplicacao <= 24:
                    taxaAliquota = 0.185;
                    break;
                case var duracao when mesesDaAplicacao > 24:
                    taxaAliquota = 0.15;
                    break;
                default:
                    throw new Exception("O valor da duração da aplicação é invalido. A operação não pode ser concluída.");
            }

            lucro = (aplicacao.valorInicial * Math.Pow(1 + taxaDeRendimento / 100, mesesDaAplicacao)) - aplicacao.valorInicial;
            lucro -= (lucro * taxaAliquota);

            return Math.Round(aplicacao.valorInicial + lucro, 2);
        }

        public double RealizarResgate(double taxaDeRendimento, DateTime dataResgate)
        {
            double valorResgatado = CalcularValorAResgatar(taxaDeRendimento, dataResgate);

            this.aplicacao.SetValorResgate(valorResgatado);
            this.aplicacao.SetDataResgate(dataResgate);

            return valorResgatado;
        }

        public int calculaDuracaoDaAplicacaoEmMeses(DateTime dataInicial, DateTime dataDoResgate)
        {
            return dataDoResgate.Day < dataInicial.Day ? (((dataDoResgate.Year - dataInicial.Year) * 12) + dataDoResgate.Month - dataInicial.Month) - 1 :
                ((dataDoResgate.Year - dataInicial.Year) * 12) + dataDoResgate.Month - dataInicial.Month;
        }
    }
}
