using Aliquota.Domain.Entities;
using Aliquota.Domain.IRepos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Applications
{
    public class AppAplicacao : IAppAplicacao
    {
        private IAplicacaoRepo _repo;

        public AppAplicacao(IAplicacaoRepo aplicacaoRepo)
        {
            _repo = aplicacaoRepo;
        }

        public async Task Adicionar(Aplicacao aplicacao)
        {
            ValidarAplicacao(aplicacao);
            await _repo.Adicionar(aplicacao);
        }
        public async Task Atualizar(Aplicacao aplicacao)
        {
            ValidarAplicacao(aplicacao);
            await _repo.Atualizar(aplicacao);
        }
        public async Task Excluir(Aplicacao aplicacao)
        {
            await _repo.Excluir(aplicacao);
        }
        public async Task<Aplicacao> ObterPorId(int aplicacaoID)
        {
            return await _repo.ObterPorId(aplicacaoID);
        }
        public async Task<IList<Aplicacao>> Listar(Predicate<Aplicacao> queryPredicate = null)
        {
            return await _repo.Listar(queryPredicate);
        }

        public decimal ImpostoRendaDevido(Aplicacao aplicacao)
        {
            var periodoAplicacao = ObterPeriodoAplicacao(aplicacao);

            var lucro = ObterLucro(aplicacao);

            decimal percentualIR = ObterPercentualIR(periodoAplicacao);

            return lucro * percentualIR;
        }

        private int ObterPeriodoAplicacao(Aplicacao aplicacao)
        {
            if (!aplicacao.DataRetirada.HasValue)
                return 0;

            return ((aplicacao.DataRetirada.Value.Year - aplicacao.DataAplicacao.Year) * 12) + aplicacao.DataRetirada.Value.Month - aplicacao.DataAplicacao.Month;
        }
        private decimal ObterLucro(Aplicacao aplicacao)
        {
            var periodoAplicacao = ObterPeriodoAplicacao(aplicacao);

            decimal rendimentoBruto = aplicacao.Valor;
            for (int i = periodoAplicacao; i > 0; i--)
            {
                rendimentoBruto = rendimentoBruto + (rendimentoBruto * (aplicacao.Produto.Rendimento / 100));
            }

            return rendimentoBruto - (aplicacao.Produto.Custo * periodoAplicacao) - aplicacao.Valor;
        }
        public decimal ObterPercentualIR(int periodoAplicacao)
        {
            if (periodoAplicacao <= 12)
                return (decimal)0.225;

            if (periodoAplicacao > 12 && periodoAplicacao <= 24)
                return (decimal)0.185;

            return (decimal)0.15;
        }

        private void ValidarAplicacao(Aplicacao aplicacao)
        {
            if (aplicacao != null && aplicacao.Valor <= 0)
                throw new ApplicationException("O valor da aplicação deve ser maior que zero (0).");

            if (aplicacao.DataRetirada.HasValue && aplicacao.DataRetirada < aplicacao.DataAplicacao)
                throw new ApplicationException("A data de retirada deve ser posterior à data de aplicação");
        }
    }
}
