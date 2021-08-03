using System;
using Aliquota.Core.DomainObjects;

namespace Aliquota.Domain.Models
{
    public class ProdutoFinanceiro : Entity, IAggregateRoot
    {
        public double Aplicacao { get; }
        public DateTime DataAplicacao { get; }
        public double Lucro { get; }
        public DateTime DataResgate { get; }

        protected ProdutoFinanceiro()
        {

        }

        public ProdutoFinanceiro(double aplicacao, DateTime dataAplicacao, double lucro, DateTime dataResgate)
        {
            ValidarAplicacao(aplicacao);

            Aplicacao = aplicacao;
            DataAplicacao = dataAplicacao;
            Lucro = lucro;

            ValidarDataDeResgate(dataResgate);
            DataResgate = dataResgate;
        }

        private void ValidarAplicacao(double aplicacao)
        {
            if(aplicacao <= 0)
            {
                throw new DomainException("A aplicação não pode ser menor ou igual a zero");
            }
        }

        internal TimeSpan CalcularTempoDeAplicacao()
        {
            return DataResgate.Subtract(DataAplicacao);
        }

        private void ValidarDataDeResgate(DateTime dataResgate)
        {
            if(dataResgate < DataAplicacao)
            {
                throw new DomainException("A Data de Resgate não pode ser menor que a Data de Aplicação");
            }
        }
    }
}