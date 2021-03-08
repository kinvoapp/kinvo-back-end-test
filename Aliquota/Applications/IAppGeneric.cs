using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Applications
{
    public interface IAppGeneric<T> where T : class
    {
        Task Adicionar(T Entity);
        Task Atualizar(T Entity);
        Task Excluir(T Entity);
        Task<T> ObterPorId(int Id);
        Task<IList<T>> Listar(Predicate<T> queryPredicate = null);
    }
}
