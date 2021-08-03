using Aliquota.Domain.Entidades.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Aliquota.Domain.Interfaces.Repositorios
{
    public interface IRepositorioBase<ChavePrimaria>
    {
        IQueryable<TipoEntidade> MontarConsultaAsync<TipoEntidade>()
            where TipoEntidade : EntidadeBase<ChavePrimaria>;

        Task<IList<TipoEntidade>> ObterTodosAsync<TipoEntidade>()
            where TipoEntidade : EntidadeBase<ChavePrimaria>;

        Task<TipoEntidade> ObterPorIdAsync<TipoEntidade>(ChavePrimaria id)
            where TipoEntidade : EntidadeBase<ChavePrimaria>;

        Task<IEnumerable<TipoEntidade>> ObterQuandoAsync<TipoEntidade>(Expression<Func<TipoEntidade, bool>> condicao)
            where TipoEntidade : EntidadeBase<ChavePrimaria>;

        Task<TipoEntidade> PrimeiroOuPadraoAsync<TipoEntidade>(Expression<Func<TipoEntidade, bool>> condicao)
            where TipoEntidade : EntidadeBase<ChavePrimaria>;

        Task AdicionarAsync<TipoEntidade>(TipoEntidade entidade)
            where TipoEntidade : EntidadeBase<ChavePrimaria>;

        Task AtualizarAsync<TipoEntidade>(TipoEntidade entidade)
            where TipoEntidade : EntidadeBase<ChavePrimaria>;

        Task RemoverAsync<TipoEntidade>(TipoEntidade entidade)
            where TipoEntidade : EntidadeBase<ChavePrimaria>;

        Task RemoverPorIdAsync<TipoEntidade>(ChavePrimaria id)
            where TipoEntidade : EntidadeBase<ChavePrimaria>;

        Task<int> ContarTodosAsync<TipoEntidade>()
            where TipoEntidade : EntidadeBase<ChavePrimaria>;

        Task<int> ContarQuandoAsync<TipoEntidade>(Expression<Func<TipoEntidade, bool>> predicate)
            where TipoEntidade : EntidadeBase<ChavePrimaria>;
    }

    public interface IRepositorioBase : IRepositorioBase<Guid>
    {
    }
}