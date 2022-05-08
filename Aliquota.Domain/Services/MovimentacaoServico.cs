using Aliquota.Domain.Entities;
using Aliquota.Domain.Interfaces.Repositories;
using Aliquota.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Services
{
    public class MovimentacaoServico : IMovimentacaoServico
    {
        private readonly IMovimentacaoRepositorio _repositorio;

        public MovimentacaoServico(IMovimentacaoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public bool Adicionar(Movimentacao movimentacao)
        {
            return _repositorio.Adicionar(movimentacao);
        }

        public bool Atualizar(int id, Movimentacao movimentacao)
        {
            return _repositorio.Atualizar(id, movimentacao);
        }

        public void Dispose()
        {
            _repositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            return _repositorio.Excluir(id);
        }

        public List<Movimentacao> ListarTodas()
        {
            return _repositorio.ListarTodas();
        }

        public Movimentacao ObterPorId(int id)
        {
            return _repositorio.ObterPorId(id);
        }

        public double ObterSaldo()
        {
            return _repositorio.ObterSaldo();
        }
    }
}