using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Applications
{
    public interface IAppGeneric<T> where T : class
    {
        void Adicionar(T Entity);
        void Atualizar(T Entity);
        void Excluir(T Entity);
        T ObterPorId(int Id);
        IList<T> Listar(Predicate<T> queryPredicate = null);
    }
}
