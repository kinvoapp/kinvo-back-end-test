using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Business.Implementacao.Business.IRStrategy
{
    public class IRMaior2anosStrategy : IImpostoRendaStrategy
    {
        private decimal _valorAtual;
        private decimal _valorInvestido;
        private readonly decimal _fatorMultiplicador = 0.15m;

        public IRMaior2anosStrategy(decimal valorAtual, decimal valorInvestido)
        {
            this._valorAtual = valorAtual;
            this._valorInvestido = valorInvestido;
        }

        public decimal CalculaImposto()
        {

            return (_valorAtual - _valorInvestido) * _fatorMultiplicador;
        }
    }
}
