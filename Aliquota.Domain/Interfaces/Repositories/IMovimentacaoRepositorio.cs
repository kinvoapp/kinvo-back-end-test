using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Aliquota.Domain.Interfaces.Repositories
{
    public interface IMovimentacaoRepositorio:IDisposable
    {
        public List<Movimentacao> ListarTodas();
        public Movimentacao ObterPorId(int id);
        public bool Adicionar(Movimentacao movimentacao);
        public bool Atualizar(int id, Movimentacao movimentacao);
        public bool Excluir(int id);

        public double ObterSaldo();
    }
}