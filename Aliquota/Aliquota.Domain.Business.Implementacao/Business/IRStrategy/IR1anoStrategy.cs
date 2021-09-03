using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Business.Implementacao.Business.IRStrategy
{
    public class IR1anoStrategy : IImpostoRendaStrategy
    {
        private decimal _valorAtual;
        private decimal _valorInvestido;
        private readonly decimal _fatorMultiplicador = 0.225m;

        public IR1anoStrategy(decimal valorAtual, decimal valorInvestido)
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
