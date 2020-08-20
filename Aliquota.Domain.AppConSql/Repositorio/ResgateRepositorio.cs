using Aliquota.Domain.AppConSql.Contexto;

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Domain.AppConSql.Repositorio
{
   class ResgateRepositorio : BaseBD<Resgate>, IBaseBD<Resgate>
   {
      public ResgateRepositorio() : base() { }

      public IEnumerable<Resgate> getAll => contexto.Resgates.Include(c => c.Cliente);
      public Resgate GetById(int id)
      {
         return contexto.Resgates.FirstOrDefault(r => r.ResgateId == id);
      }


      public int Count()
      {
         return contexto.Resgates.Count();

      }



      public void TruncateTable()
      {

         this.TruncateTable<Resgate>(contexto.Resgates);
         contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Resgates', RESEED, 1)", "");

         //  DELETE FROM MyTableName;
         //  DELETE FROM SQLITE_SEQUENCE WHERE NAME = 'MyTableName';
      }

   }
}
