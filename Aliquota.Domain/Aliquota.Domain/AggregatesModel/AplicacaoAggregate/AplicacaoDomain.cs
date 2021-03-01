using System;
using System.Collections.Generic;
using System.Text;

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
            TimeSpan duracaoAplicacao = dataDoResgate - aplicacao.dataInicial;
            double taxaAliquota;
            double lucro;

            switch (duracaoAplicacao)
            {
                case var duracao when duracao.Days < 365 && duracao.Days >= 0:
                    taxaAliquota = 0.225;
                    break;
                case var duracao when duracao.Days >= 365 && duracao.Days <= 730:
                    taxaAliquota = 0.185;
                    break;
                case var duracao when duracao.Days > 730:
                    taxaAliquota = 0.15;
                    break;
                default:
                    throw new Exception("O valor da duração da aplicação é invalido. A operação não pode ser concluída.");
            }

            lucro = (aplicacao.valorInicial * Math.Pow(1 + taxaDeRendimento / 100, duracaoAplicacao.Days / 30)) - aplicacao.valorInicial;
            lucro -= (lucro * taxaAliquota);

            return aplicacao.valorInicial + lucro;
        }
    }
}
