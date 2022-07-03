using Aliquota.Domain.Models;

namespace Aliquota.Domain.Interfaces
{
    public interface IPosicaoRepository : IRepository<Posicao>
    {
        Task<IEnumerable<Posicao>> ObterPosicoesPorProduto(Guid id);
        Task<Posicao> ObterProdutoPosicao(Guid id);
    }
}
