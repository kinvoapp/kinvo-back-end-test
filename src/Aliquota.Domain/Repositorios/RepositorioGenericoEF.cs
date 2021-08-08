using Aliquota.Domain.Infraestrutura.DBConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Domain.Repositorios
{
    public abstract class RepositorioGenericoEF<T> where T : class
    {
        protected AliquotaContexto _contexto;

        protected RepositorioGenericoEF(AliquotaContexto contexto)
        {
            _contexto = contexto;
        }

        protected virtual async Task Alterar(T obj)
        {
            _contexto.Set<T>().Update(obj);
            await _contexto.SaveChangesAsync();
        }

        protected virtual async Task<T> BuscaPorId(Guid id)
        => await _contexto.FindAsync<T>(id);

        protected virtual async Task Excluir(T obj)
        {
            _contexto.Set<T>().Remove(obj);
            await _contexto.SaveChangesAsync();
        }

        protected virtual async Task Incluir(T obj)
        {
            await _contexto.Set<T>().AddAsync(obj);
            await _contexto.SaveChangesAsync();
        }

        protected virtual async Task<IEnumerable<T>> Todos()
        => await _contexto.Set<T>().ToListAsync();
    }
}
