using System.Collections.Generic;

namespace Aliquota.Domain.Shared
{
    public interface IRepository<T> where T : EntidadeBase
    {
        bool InserirNovo(T registry);
        bool Resgatar(int id, T registry);
        List<T> SelecionartTodos();
        T SelecionarPorId(int id);
    }
}
