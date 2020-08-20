using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;



namespace Aliquota.Domain.AppConSql.Repositorio
{
   public interface IBaseBD<T>
   {
      IEnumerable<T> getAll { get; }

       T GetById(int id);

      void Save(T info);
      void Update(T info);

      void TruncateTable<T>(DbSet<T> dbSet) where T : class;

   }
}
