using System;
using System.Collections.Generic;
using src.Models;

namespace src.Interfaces.IServices
{
    public interface IResgateFundoService
    {
       bool SalvarResgateFundo(ResgateFundo pResgateFundo);
       ResgateFundo ObterResgateFundo(int pId);
       List<ResgateFundo> ListarResgateFundo();
    }
}
