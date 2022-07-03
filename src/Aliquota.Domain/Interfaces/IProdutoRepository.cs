using Aliquota.Domain.Models;

namespace Aliquota.Domain.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<Produto> ObterPosicoesProduto(Guid id);

        Task<Produto> ObterPosicoesAtivasProduto(Guid id);
    }
}
