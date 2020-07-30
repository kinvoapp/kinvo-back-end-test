using System;
using System.Collections.Generic;
using src.Models;

namespace src.Interfaces.IServices
{
    public interface IFundoInvestimentoService
    {
       bool SalvarFundoInvestimento(FundoInvestimento pFundoInvestimento);
       FundoInvestimento ObterFundoInvestimento(int pId);
       List<FundoInvestimento> ListarFundoInvestimento();
    }
}
