using Aliquota.Domain.AppConsole.Contexto;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.AppConsole.Repositorio
{
   class BaseBD<T>
   {
      public Context contexto { get; }

      public BaseBD()
      {
         contexto = new Context();
      }
      public void Save(T info)
      {
         contexto.Add(info);
      }

      public void Update(T info)
      {
         contexto.Update(info);
      }

      public void SaveChanges()
      {
         contexto.SaveChanges();
      }


      public void TruncateTable<T>(DbSet<T> dbSet) where T : class 
      {
         dbSet.RemoveRange(dbSet);
         SaveChanges();
      }

   }
}
