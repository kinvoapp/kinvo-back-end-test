using System;

namespace Aliquota.Domain.Servicos.CalculoIR.Calculos
{
    public interface ICalculoIR
    {
        void FazCalculo(ref double valorIR, double lucro, DateTime dataAplicacao, DateTime dataResgate);
    }
}
