using Aliquota.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aliquota.DAL;

namespace Aliquota.DAL
{
    public class RepositorioGeneric<T> : IGeneric<T>, IDisposable where T : class
    {
        private readonly DbContextOptionsBuilder<AliquotaDBContext> _OptionsBuider;

        public RepositorioGeneric()
        {
            _OptionsBuider = new DbContextOptionsBuilder<AliquotaDBContext>();
        }


        public void Insert(T Entity)
        {
            using (var banco = new AliquotaDBContext(_OptionsBuider.Options))
            {
                banco.Set<T>().Add(Entity);
                banco.SaveChanges();
            }
        }

        public void Delete(T Entity)
        {
            using (var banco = new AliquotaDBContext(_OptionsBuider.Options))
            {
                banco.Set<T>().Remove(Entity);
                banco.SaveChanges();
            }
        }


        public T GetEntity(int Id)
        {
            using (var banco = new AliquotaDBContext(_OptionsBuider.Options))
            {
                return banco.Set<T>().Find(Id);

            }
        }

        public List<T> GetAll()
        {
            using (var banco = new AliquotaDBContext(_OptionsBuider.Options))
            {
                return banco.Set<T>().AsNoTracking().ToList();

            }
        }

        public void Update(T Entity)
        {
            using (var banco = new AliquotaDBContext(_OptionsBuider.Options))
            {
                banco.Set<T>().Update(Entity);
                banco.SaveChanges();
            }
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDispose)
        {
            if (!isDispose) return;
        }

        ~RepositorioGeneric()
        {
            Dispose(false);
        }
    }
}
