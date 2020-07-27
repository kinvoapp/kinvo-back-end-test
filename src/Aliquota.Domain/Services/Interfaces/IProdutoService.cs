using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Services.Interfaces
{
    public interface IProdutoService
    {
        Aplicacao ObterPorId(Guid id);

        IEnumerable<Aplicacao> ObterTodos();

        Aplicacao Aplicar(Aplicacao aplicacao);

        Resgate Resgatar(Aplicacao aplicacao, DateTime dataResgate);

        IEnumerable<Resgate> ResgatarTodosDisponiveis(DateTime dataResgate);
    }
}
