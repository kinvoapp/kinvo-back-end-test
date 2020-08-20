using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.AppConSql.UtilClass
{
   class Util
   {

      // Obitido de www.macoratti.net
      public static void  DiferencaEntreDatas(DateTime inicio, DateTime final, out int dias, out int meses, out int anos)
      {
         int[] diasDoMes = new int[12] { 31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
         int incremento;

         incremento = 0;

         if (inicio.Day > final.Day)
         {
            incremento = diasDoMes[inicio.Month - 1];
         }
         if (incremento == -1)
         {
            if (DateTime.IsLeapYear(inicio.Year))
            {
               incremento = 29;
            }
            else
            {
               incremento = 28;
            }
         }
         if (incremento != 0)
         {
            dias = (final.Day + incremento) - inicio.Day;
            incremento = 1;
         }
         else
         {
            dias = final.Day - inicio.Day;
         }

         if ((inicio.Month + incremento) > final.Month)
         {
            meses = (final.Month + 12) - (inicio.Month + incremento);
            incremento = 1;
         }
         else
         {
            meses = (final.Month) - (inicio.Month + incremento);
            incremento = 0;
         }

         anos = final.Year - (inicio.Year + incremento);
      }

   }
}
