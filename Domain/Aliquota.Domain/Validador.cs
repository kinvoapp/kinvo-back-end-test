using System;
using System.Diagnostics.Contracts;

static class Validador
{
   [ContractArgumentValidator]
   public static void NaoNulo(object argument, string parameterName)
   {
      if (argument == null) throw new ArgumentNullException(parameterName,
                                                            "Parametro nao pode ser nulo.");
      Contract.EndContractBlock();
   }

   [ContractArgumentValidator]
   public static void MaiorQueZero(decimal argument, string parameterName)
   {
      NaoNulo(argument, parameterName);

      if (argument <= 0) throw new ArgumentException(parameterName,
                                                            "O parametro precisa ser maior que zero.");
      Contract.EndContractBlock();
   }
   
   [ContractArgumentValidator]
   public static void MaiorQueData(DateTime date1, DateTime date2)
   {
      if (date2 > date1) {throw new ArgumentException($"A data 1 precisa ser maior que a data 2");}
      Contract.EndContractBlock();
   }
}