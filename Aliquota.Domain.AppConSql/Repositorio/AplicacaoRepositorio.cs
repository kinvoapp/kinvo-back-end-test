using Aliquota.Domain.AppConSql.Contexto;

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Domain.AppConSql.Repositorio
{
   class AplicacaoRepositorio : BaseBD<Aplicacao>, IBaseBD<Aplicacao>
   {
      public AplicacaoRepositorio() : base() { }

      public IEnumerable<Aplicacao> getAll => contexto.Aplicacoes.Include(c => c.Cliente);

      public Aplicacao GetById(int id)
      {
         return contexto.Aplicacoes.FirstOrDefault(a => a.AplicacaoId == id);
      }


      public int Count()
      {
         return contexto.Aplicacoes.Count();

      }



      public void TruncateTable()
      {

         this.TruncateTable<Aplicacao>(contexto.Aplicacoes);
         contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Aplicacoes', RESEED, 1)", "");

         //  DELETE FROM MyTableName;
         //  DELETE FROM SQLITE_SEQUENCE WHERE NAME = 'MyTableName';
      }

   }
}
