using Aliquota.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Aliquota.Infrastructure.Shared
{
    public class RepositoryBase<T> where T : EntidadeBase
    {
        protected readonly AliquotaDBContext db;
        protected readonly DbSet<T> dbSet;
        protected RepositoryBase(AliquotaDBContext db)
        {
            this.db = db;
            dbSet = db.Set<T>();
        }

        public bool InserirNovo(T registry)
        {
            dbSet.Add(registry);
            db.SaveChanges();

            return true;
        }

        public virtual bool Resgatar(int id, T registry)
        {
            T temp = db.Set<T>()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            registry.Id = id;

            db.Entry(temp).CurrentValues.SetValues(registry);

            foreach (var navNewObj in db.Entry(registry).Navigations)
                foreach (var navOldExist in db.Entry(temp).Navigations)
                    if (navNewObj.Metadata.Name == navOldExist.Metadata.Name)
                        navOldExist.CurrentValue = navNewObj.CurrentValue;

            db.Update(temp);
            db.SaveChanges();

            return true;
        }

        public virtual T SelecionarPorId(int id)
        {
            return db.Set<T>()
            .Where(x => x.Id == id)
            .FirstOrDefault();
        }

        public virtual List<T> SelecionartTodos()
        {
            return db.Set<T>().ToList();
        }
    }
}
