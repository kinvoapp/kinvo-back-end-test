using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Dao
{
    public class BaseDao<Entity, Key> where Entity:class
    {
        DbSet<Entity> dbSet;

        protected BaseDao(DbSet<Entity> dbSet)
        {
            this.dbSet = dbSet;
        }

        public void Insert(Entity entity)
        {
            dbSet.Add(entity);
        }

        public Entity Find(Key id)
        {
            return dbSet.Find(new object[] { id });
        }

    }
}
