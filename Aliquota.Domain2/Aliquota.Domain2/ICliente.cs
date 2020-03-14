using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain
{
    interface ICliente
    {
        void adicionarValorInvestido(double valor);
        void resgatar(double valor);
        void inserirDataIncialAplicacao(int mes, int ano);
        void inserirDataFinalAplicacao(int mes, int ano);
    }
}
