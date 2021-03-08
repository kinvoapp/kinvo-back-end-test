using System;
using System.Collections.Generic;

namespace Aliquota.Domain.IRepos
{
    public interface IGenericRepository<TEntityModel,TPrimaryKey> where TEntityModel : class 
    {
        void Adicionar(TEntityModel Objeto);

        void Atualizar(TEntityModel Objeto);     

        void Excluir(TEntityModel Objeto);

        TEntityModel ObterPorId(TPrimaryKey Id);

        IList<TEntityModel> Listar(Predicate<TEntityModel> queryPredicate = null);
    }
}
