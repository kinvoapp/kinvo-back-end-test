using Aliquota.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Application.Interfaces
{
    public interface IAplicacaoService : IDisposable
    {
        Task<List<AplicacaoViewModel>> ObterTodos();
        Task<AplicacaoViewModel> ObterPorId(Guid id);

        Task<bool> Adicionar(AplicacaoCreateViewModel o);

        Task<bool> Atualizar(AplicacaoEditViewModel o);

        Task<bool> Excluir(Guid id);

    }
}
