using Aliquota.Domain.AppConSql.Contexto;

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Domain.AppConSql.Repositorio
{
   class ClienteRepositorio : BaseBD<Cliente>, IBaseBD<Cliente>
   {
      public ClienteRepositorio() : base() { }

      public IEnumerable<Cliente> getAll => contexto.Clientes.Include(a => a.Aplicacoes).Include(r => r.Resgates);

      public Cliente GetById(int id)
      {
         Cliente cliente;

         cliente = contexto.Clientes.Where(c => c.ClienteId == id).Include(c => c.Aplicacoes).Include(c => c.Resgates).FirstOrDefault();
         return cliente;

      }

      public int Count()
      {
         return contexto.Clientes.Count();
       
      }


      public void TruncateTable()
      {

         this.TruncateTable<Cliente>(contexto.Clientes);
         contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Clientes', RESEED, 1)", "");

         //  DELETE FROM MyTableName;
         //  DELETE FROM SQLITE_SEQUENCE WHERE NAME = 'MyTableName';
      }

   }
}
