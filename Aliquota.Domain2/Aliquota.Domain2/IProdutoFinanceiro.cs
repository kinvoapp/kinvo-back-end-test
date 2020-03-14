using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain
{
    interface IProdutoFinanceiro
    {
        int calcularTempoAplicacao(Date d1, Date d2);
        double tratarResgateCliente(double valor);
        double tratarDepositoCliente(double valor);
        void novaDataIncialAplicacao(int mes, int ano);
        void novaDataFinalAplicacao(int mes, int ano);
    }
}
