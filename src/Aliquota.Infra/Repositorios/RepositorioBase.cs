using Aliquota.Domain.Entidades.Base;
using Aliquota.Domain.Infra.Contextos.Base;
using Aliquota.Domain.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Aliquota.Domain.Infra.Repositorios
{
    public class RepositorioBase<TipoContexto, ChavePrimaria> : IRepositorioBase<ChavePrimaria>, IDisposable
        where TipoContexto : ContextoBase
    {
        protected readonly TipoContexto contexto;

        public RepositorioBase(TipoContexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task<TipoEntidade> ObterPorIdAsync<TipoEntidade>(ChavePrimaria id)
            where TipoEntidade : EntidadeBase<ChavePrimaria>
        {
            return await contexto.Set<TipoEntidade>().FindAsync(id);
        }

        public async Task<IEnumerable<TipoEntidade>> ObterQuandoAsync<TipoEntidade>(Expression<Func<TipoEntidade, bool>> condicao)
            where TipoEntidade : EntidadeBase<ChavePrimaria>
        {
            return await contexto.Set<TipoEntidade>().Where(condicao).ToListAsync();
        }

        public async Task<IList<TipoEntidade>> ObterTodosAsync<TipoEntidade>()
            where TipoEntidade : EntidadeBase<ChavePrimaria>
        {
            return await contexto.Set<TipoEntidade>().ToListAsync();
        }

        public IQueryable<TipoEntidade> MontarConsultaAsync<TipoEntidade>()
            where TipoEntidade : EntidadeBase<ChavePrimaria>
        {
            return contexto.Set<TipoEntidade>();
        }

        public async Task<TipoEntidade> PrimeiroOuPadraoAsync<TipoEntidade>(Expression<Func<TipoEntidade, bool>> condicao)
            where TipoEntidade : EntidadeBase<ChavePrimaria>
        {
            return await contexto.Set<TipoEntidade>().FirstOrDefaultAsync(condicao);
        }

        public async Task AdicionarAsync<TipoEntidade>(TipoEntidade entidade)
            where TipoEntidade : EntidadeBase<ChavePrimaria>
        {
            await contexto.Set<TipoEntidade>().AddAsync(entidade);
            await contexto.SaveChangesAsync();
        }

        public async Task AtualizarAsync<TipoEntidade>(TipoEntidade entidade)
            where TipoEntidade : EntidadeBase<ChavePrimaria>
        {
            contexto.Set<TipoEntidade>().Update(entidade);
            await contexto.SaveChangesAsync();
        }

        public async Task RemoverAsync<TipoEntidade>(TipoEntidade entidade)
            where TipoEntidade : EntidadeBase<ChavePrimaria>
        {
            contexto.Set<TipoEntidade>().Remove(entidade);
            await contexto.SaveChangesAsync();
        }

        public async Task RemoverPorIdAsync<TipoEntidade>(ChavePrimaria id)
            where TipoEntidade : EntidadeBase<ChavePrimaria>
        {
            var entidade = await ObterPorIdAsync<TipoEntidade>(id).ConfigureAwait(false);
            if (entidade != null)
            {
                contexto.Set<TipoEntidade>().Remove(entidade);
                await contexto.SaveChangesAsync();
            }
        }

        public async Task<int> ContarQuandoAsync<TipoEntidade>(Expression<Func<TipoEntidade, bool>> predicate)
            where TipoEntidade : EntidadeBase<ChavePrimaria>
        {
            return await contexto.Set<TipoEntidade>().CountAsync(predicate);
        }

        public async Task<int> ContarTodosAsync<TipoEntidade>()
            where TipoEntidade : EntidadeBase<ChavePrimaria>
        {
            return await contexto.Set<TipoEntidade>().CountAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                contexto.Dispose();
        }
    }

    internal class RepositorioBase<TipoContexto> : RepositorioBase<TipoContexto, Guid>, IRepositorioBase
        where TipoContexto : ContextoBase
    {
        public RepositorioBase(TipoContexto context) : base(context)
        {
        }
    }
}