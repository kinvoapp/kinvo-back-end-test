using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Domain.IRepos
{
    public interface IGenericRepository<TEntityModel,TPrimaryKey> where TEntityModel : class 
    {
        Task Adicionar(TEntityModel Objeto);

        Task Atualizar(TEntityModel Objeto);

        Task Excluir(TEntityModel Objeto);

        Task<TEntityModel> ObterPorId(TPrimaryKey Id);

        Task<IList<TEntityModel>> Listar(Predicate<TEntityModel> queryPredicate = null);
    }
}
