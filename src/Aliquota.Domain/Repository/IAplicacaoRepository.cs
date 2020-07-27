using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Aliquota.Domain.Repository
{
    public interface IAplicacaoRepository
    {
        Aplicacao ObterPorId(Guid id);

        IEnumerable<Aplicacao> ObterTodos();

        IEnumerable<Aplicacao> ObterTodos(Expression<Func<Aplicacao, bool>> filtro);

        Aplicacao Inserir(Aplicacao aplicacao);

        Aplicacao Atualizar(Aplicacao aplicacao);
    }
}
