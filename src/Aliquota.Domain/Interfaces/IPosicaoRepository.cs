using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Interfaces
{
    public interface IPosicaoRepository : IRepository<Posicao>
    {
        Task<IEnumerable<Posicao>> ObterPosicoesPorProduto(Guid id);
        Task<Posicao> ObterProdutoPosicao(Guid id);
    }
}
