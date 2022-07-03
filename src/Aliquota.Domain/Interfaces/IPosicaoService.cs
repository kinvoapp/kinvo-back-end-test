using Aliquota.Domain.Models;

namespace Aliquota.Domain.Interfaces
{
    public interface IPosicaoService : IDisposable
    {
        Task Adicionar(Posicao posicao);
        Task Atualizar(Posicao posicao);
        Task Remover(Guid id);
    }
}
