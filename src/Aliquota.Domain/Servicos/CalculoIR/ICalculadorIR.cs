using System;

namespace Aliquota.Domain.Servicos.CalculoIR
{
    public interface ICalculadorIR
    {
        double CalculaIR(double lucro,DateTime dataAplicacao,DateTime dataResgate);
    }
}
