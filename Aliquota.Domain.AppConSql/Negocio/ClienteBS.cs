using Aliquota.Domain.AppConSql.Contexto;
using Aliquota.Domain.AppConSql.Repositorio;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Aliquota.Domain.AppConSql.Negocio
{
   class ClienteBS
   {
      private readonly ClienteRepositorio dao;
      public ClienteBS( ) 
      {
         dao = new ClienteRepositorio();
      } 

      public IEnumerable<Cliente> getAll()
      {
         return dao.getAll;
      }

      public Cliente GetById(int id)
      {
         return dao.GetById(id);
      }

      public void save(Cliente cliente)
      {
         dao.Save(cliente);
      }
      public void saveChanges()
      {
         dao.SaveChanges();
      }

      public void popularClientes()
      {

         if (Count() == 0) {

            dao.TruncateTable();

            save(new Cliente { Nome = "João" });
            save(new Cliente { Nome = "Ana" });
            save(new Cliente { Nome = "Rita" });
            saveChanges();
         }
      }

   public int Count()
      {
         return dao.Count();
      }


   }
}
