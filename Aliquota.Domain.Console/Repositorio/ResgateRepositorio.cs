using Aliquota.Domain.AppConsole.Contexto;

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Domain.AppConsole.Repositorio
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

         //         this.TruncateTable<Resgate>(contexto.Resgates);
         //         contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Resgates', RESEED, 1)", "");

         contexto.Database.ExecuteSqlRaw("DELETE FROM Resgates");
         contexto.Database.ExecuteSqlRaw("DELETE FROM SQLITE_SEQUENCE WHERE NAME = 'Resgates'");
         //  DELETE FROM MyTableName;
         //  DELETE FROM SQLITE_SEQUENCE WHERE NAME = 'MyTableName';
      }

   }
}
