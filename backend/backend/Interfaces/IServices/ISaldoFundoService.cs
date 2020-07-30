using System;
using System.Collections.Generic;
using src.Models;

namespace kinvo.api.Interfaces.IServices
{
    public interface ISaldoFundoService
    {
        bool SalvarSaldoFundo(SaldoFundo pSaldoFundo);
        SaldoFundo ObterSaldoFundo (int pId);
        List<SaldoFundo> ListarSaldoFundo();
    }
}
