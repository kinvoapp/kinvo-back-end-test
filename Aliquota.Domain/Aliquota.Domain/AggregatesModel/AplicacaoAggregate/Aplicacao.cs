using System;
using System.Collections.Generic;
using System.Text;
using Aliquota.Domain.SeedWork;

namespace Aliquota.Domain.AggregatesModel.AplicacaoAggregate
{
    public class Aplicacao : Entity
    {
        public double valorInicial { get; private set; }
        public DateTime dataInicial { get; private set; }
        public DateTime? dataResgate { get; private set; }

        public int? usuarioId { get; private set; }

        public int? produtoFinanceiroId { get; private set; }

        protected Aplicacao() { }

        public Aplicacao(double valorInicial,  int produtoFinanceiroId, int usuarioId)
        {
            SetValorInicial(valorInicial);
            this.dataInicial = DateTime.UtcNow;
            this.produtoFinanceiroId = produtoFinanceiroId;
            this.usuarioId = usuarioId;
        }

        private void SetValorInicial(double valorInicial)
        {
            if (valorInicial < 0)
                throw new Exception("Valor inicial de investimento é inválido.");
            this.valorInicial = valorInicial;
        }

        public void SetDataResgate()
        {
            dataResgate = DateTime.UtcNow;
        }

        

    }
}
