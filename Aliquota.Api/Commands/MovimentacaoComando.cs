using Aliquota.Application.ApplicationService;
using Aliquota.Application.DTO;
using Aliquota.Infasctruture.Repository;
using Aliquota.Domain.Interfaces.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Api.Commands
{
    internal class MovimentacaoComando
    {
        IMovimentacaoRepositorio _repositorio;
        IMovimentacaoServico _servico;
        MovimentacaoServicoApp movimentacaoServicoApp;

        public MovimentacoComando()
        {
            _repositorio = new MovimentacaoRepositorio();
            _servico = new MovimentacaoServico(_repositorio);
            movimentacaoServicoApp = new MovimentacaoServicoApp(_servico);
        }

        public bool Adicionar(MovimentacaoDTO movimentacao)
        {
            return movimentacaoServicoApp.Adicionar(movimentacao);
        }

        public bool Atualizar(MovimentacaoDTO movimentacao)
        {
            return movimentacaoServicoApp.Atualizar(id, movimentacao);
        }

        public bool Excluir(int id )
        {
            return movimentacaoServicoApp.Excluir(id);
        }

        public MovimentacaoDTO ObterPorId(int id)
        {
            return movimentacaoServicoApp.ObterPorId(id);
        }

        public List<MovimentacaoDTO> ListarTodas()
        {
            return movimentacaoServicoApp.ListarTodas();
        }
    }
}