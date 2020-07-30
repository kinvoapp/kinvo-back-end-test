using System;
using System.Collections.Generic;
using src.Models;

namespace src.Interfaces.IServices
{
    public interface IAplicacaoFundoService
    {
       bool SalvarAplicacaoFundo(AplicacaoFundo pAplicacaoFundo);
       AplicacaoFundo ObterAplicacaoFundo(int pId);
       List<AplicacaoFundo> ListarSaldoFundo();
    }
}
