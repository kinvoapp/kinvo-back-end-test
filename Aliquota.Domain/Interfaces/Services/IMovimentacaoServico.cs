using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Interfaces.Services
{
    public interface IMovimentacaoServico:IDisposable
    {
        public List<Movimentacao> ListarTodas();
        public Movimentacao ObterPorId(int id);
        public Movimentacao ObterPorGuid(Guid guid);
        public bool Adicionar(Movimentacao movimentacao);
        public bool Atualizar(int id, Movimentacao movimentacao);
        public bool Excluir(int id);
    }
}