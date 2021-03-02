using Aliquota.Domain.SeedWork;
using System;

namespace Aliquota.Domain.AggregatesModel.AplicacaoAggregate
{
    public class Aplicacao : Entity
    {
        public double valorInicial { get; private set; }

        public double? valorResgate { get; private set; }
        public DateTime dataInicial { get; private set; }
        public DateTime? dataResgate { get; private set; }

        public int? usuarioId { get; private set; }

        public int? produtoFinanceiroId { get; private set; }

        protected Aplicacao() { }

        public Aplicacao(double valorInicial, int produtoFinanceiroId, int usuarioId)
        {
            SetValorInicial(valorInicial);
            this.dataInicial = DateTime.UtcNow;
            this.produtoFinanceiroId = produtoFinanceiroId;
            this.usuarioId = usuarioId;
        }

        private void SetValorInicial(double valorInicial)
        {
            if (valorInicial <= 0)
                throw new Exception("Valor inicial de investimento é inválido. O valor deve ser maior que zero.");
            this.valorInicial = valorInicial;
        }

        public void SetDataResgate(DateTime dataResgate)
        {
            if (dataResgate < dataInicial)
                throw new Exception("A data de resgate da aplicação é invalida. A data de resgate não pode ser anterior a data inicial da aplicação.");
            this.dataResgate = dataResgate;
        }

        public void SetValorResgate(double valor)
        {
            this.valorResgate = valor;
        }



    }
}
