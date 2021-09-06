
using Domain.Interfaces.Generics;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Generics
{
    public class RepositoryGenerics<T> : IGeneric<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public RepositoryGenerics()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task Add(T Objeto)
        {
            using (var db = new ContextBase(_OptionsBuilder))
            {
                await db.Set<T>().AddAsync(Objeto);
                await db.SaveChangesAsync();
            }
        }

        public async Task Delete(T Objeto)
        {
            using (var db = new ContextBase(_OptionsBuilder))
            {
                db.Set<T>().Remove(Objeto);
                await db.SaveChangesAsync();
            }
        }

        public async Task<T> GetEntityById(int Id)
        {
            using (var db = new ContextBase(_OptionsBuilder))
            {
                return await db.Set<T>().FindAsync(Id);
            }
        }
        public async Task<List<T>> List()
        {
            using (var db = new ContextBase(_OptionsBuilder))
            {
                return await db.Set<T>().AsNoTracking().ToListAsync();
            }
        }


        private bool _disposed = false;

        // Instantiate a SafeHandle instance.
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose() => Dispose(true);

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // Dispose managed state (managed objects).
                _safeHandle?.Dispose();
            }

            _disposed = true;
        }
    }
}
