using Aliquota.Domain.AppConSql.Contexto;
using Aliquota.Domain.AppConSql.Repositorio;
using Aliquota.Domain.AppConSql.UtilClass;

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace Aliquota.Domain.AppConSql.Negocio
{
   class ResgateBS
   {
      private readonly ResgateRepositorio dao;
      public ResgateBS( ) 
      {
         dao = new ResgateRepositorio();
      } 

      public IEnumerable<Resgate> getAll()
      {
         return dao.getAll;
      }

      public Resgate GetById(int id)
      {
         return dao.GetById(id);
      }

      public void save(Resgate resgate)
      {
         dao.Save(resgate);
      }

      public void saveChanges()
      {
         dao.SaveChanges();
      }



      public void Update(Resgate resgate)
      {
         dao.Update(resgate);
      }

      public DateTime getDataRandom()
      {
         Random random = new Random();
         return DateTime.Now.AddDays(((random.Next(3) * 370) + 200) * -1);
      }



      public int Count()
      {
         return dao.Count();
      }

   }
}
