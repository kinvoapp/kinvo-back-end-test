using Aliquota.Domain.Shared;
using System.Collections.Generic;

namespace Aliquota.Applications.Shared
{
    public abstract class ApplicationBase<T> where T : EntidadeBase
    {
        public abstract bool AddEntidade(T entidade);
        public abstract bool EditarEntidade(int id, T entidade);
        public abstract T SelecionarEntidadePorId(int id);
        public abstract List<T> SelecionarTodasEntidades();
    }
}