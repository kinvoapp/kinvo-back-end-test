using Aliquota.Domain.AppConsole.Contexto;
using Aliquota.Domain.AppConsole.Repositorio;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Aliquota.Domain.AppConsole.Negocio
{
   class RendimentoBS
   {
      private readonly RendimentoRepositorio dao;
      public RendimentoBS( ) 
      {
         dao = new RendimentoRepositorio();
      } 

      public IEnumerable<Rendimento> getAll()
      {
         return dao.getAll;
      }

      public Rendimento GetById(int id)
      {
         return dao.GetById(id);
      }

      public void save(Rendimento rendimento)
      {
         dao.Save(rendimento);
      }
      public void saveChanges()
      {
         dao.SaveChanges();
      }


      protected decimal getValorPercentual ()
      {
         int rnd;
         decimal num = 0;
         Random random = new Random();

         rnd = random.Next(10);
         if (rnd == 1)
         {
            num = (decimal)(random.Next(6) / -10.0f);
         }
         else
         {
            num = (decimal)(rnd / 10.0f);
         }
         return num;

      }

      public void popularRendimentos()
      {
         decimal num;
         DateTime inicio = DateTime.Now.AddDays(-2000);
         Random   random = new Random();

         dao.TruncateTable();
         saveChanges();

         while (inicio <= DateTime.Now)
         {
            num = getValorPercentual();
            save(new Rendimento { Data = inicio, Percentual = num });
            
            inicio = inicio.AddDays(1);
         }
         saveChanges();
      }


      public DateTime? getMaxDataRendimento()
      {
         return dao.getMaxDataRendimento();
      }


      public DateTime? getMinDataRendimento()
      {
         return dao.getMinDataRendimento();
      }


      public Rendimento GetRendimentoByData(DateTime data)
      {
         return dao.getRendimentoByData(data);
      }


      public void atualizarRendimentos()
      {

         decimal   num; 
         DateTime? ultimaData = getMaxDataRendimento();
         DateTime  dataReal;

         if (ultimaData == null)
         {
            popularRendimentos();
         }
         else
         {
            dataReal = ((DateTime)ultimaData).AddDays(1);
            while (dataReal <= DateTime.Now)
            {
               num = getValorPercentual();
               save(new Rendimento { Data = dataReal, Percentual = num });
               dataReal = dataReal.AddDays(1);
            }
            saveChanges();
         }


      }

      public int Count()
      {
         return dao.Count();
      }




   }
}
