using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Interfaces
{
    public interface IPosicaoService : IDisposable
    {
        Task Adicionar(Posicao posicao);
        Task Atualizar(Posicao posicao);
        Task Remover(Guid id);
    }
}
