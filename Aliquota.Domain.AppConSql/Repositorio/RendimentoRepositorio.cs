using Aliquota.Domain.AppConSql.Contexto;

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Domain.AppConSql.Repositorio
{
   class RendimentoRepositorio : BaseBD<Rendimento>, IBaseBD<Rendimento>
   {
      public RendimentoRepositorio() : base() { }

      public IEnumerable<Rendimento> getAll => contexto.Rendimentos;

      public Rendimento GetById(int id)
      {
         return contexto.Rendimentos.FirstOrDefault(r => r.RendimentoId == id);
      }

      public void TruncateTable()
      {

         this.TruncateTable<Rendimento>(contexto.Rendimentos);
         contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Rendimentos', RESEED, 1)", "");

         //  DELETE FROM MyTableName;
         //  DELETE FROM SQLITE_SEQUENCE WHERE NAME = 'MyTableName';
      }

      public DateTime? getMaxDataRendimento()
      {
         return contexto.Rendimentos.Max(r => (DateTime?)r.Data);
      }
      public DateTime? getMinDataRendimento()
      {
         return contexto.Rendimentos.Min(r => (DateTime?)r.Data);
      }

      public Rendimento getRendimentoByData(DateTime  data)
      {
         return contexto.Rendimentos.Where(r => r.Data == data).FirstOrDefault();

      }

      public int Count()
      {
         return contexto.Rendimentos.Count();

      }



   }
}
