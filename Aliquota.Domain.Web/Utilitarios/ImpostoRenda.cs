using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain
{
  public class ImpostoRenda
  {
   
    private decimal CalculaTaxaLucro(DateTime dataAplicacao, DateTime DataResgate)
    {
      int anosDecorridos = CalculaTempoAnos(dataAplicacao, DataResgate);
      if (anosDecorridos == 0)
      {
        return 22.5M;
      } else if (anosDecorridos == 1)
      {
        return 18.5M;
      } else if (anosDecorridos >= 2)
      {
        return 15M;
      }else if (anosDecorridos < 0)
      {
        throw new Exception("A data de resgate não pode ser menor que a data de aplicação");
      }
      throw new Exception("Erro, Data invalida");
    }

    public static int CalculaTempoAnos(DateTime dataInicio, DateTime dataFim)
    {
      int anosDecorridos = dataFim.Year - dataInicio.Year;

      if (dataFim.Month < dataInicio.Month || (dataFim.Month == dataInicio.Month && dataFim.Day < dataInicio.Day))
        anosDecorridos--;

      return anosDecorridos;
    }

  }
}
