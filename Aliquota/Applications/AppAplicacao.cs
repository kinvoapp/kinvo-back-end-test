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

        public async Task Adicionar(Aplicacao a_Aplicacao)
        {
            ValidarAplicacao(a_Aplicacao);
            await _repo.Adicionar(a_Aplicacao);
        }
        public async Task Atualizar(Aplicacao a_Aplicacao)
        {
            ValidarAplicacao(a_Aplicacao);
            await _repo.Atualizar(a_Aplicacao);
        }
        public async Task Excluir(Aplicacao a_Aplicacao)
        {
            await _repo.Excluir(a_Aplicacao);
        }
        public async Task<Aplicacao> ObterPorId(int a_AplicacaoID)
        {
            return await _repo.ObterPorId(a_AplicacaoID);
        }
        public async Task<IList<Aplicacao>> Listar(Predicate<Aplicacao> queryPredicate = null)
        {
            return await _repo.Listar(queryPredicate);
        }

        public decimal ImpostoRendaDevido(Aplicacao a_Aplicacao)
        {
            if (!a_Aplicacao.DataRetirada.HasValue)
                return 0;
            
            int l_PeriodoAplicacao = ((a_Aplicacao.DataRetirada.Value.Year - a_Aplicacao.DataAplicacao.Year) * 12) + a_Aplicacao.DataRetirada.Value.Month - a_Aplicacao.DataAplicacao.Month;

            decimal l_RendimentoBruto = a_Aplicacao.Valor;
            for (int i = l_PeriodoAplicacao; i > 0; i--)
            {
                l_RendimentoBruto = l_RendimentoBruto + (l_RendimentoBruto * a_Aplicacao.Produto.Rendimento);
            }

            decimal l_Lucro = l_RendimentoBruto - (a_Aplicacao.Produto.Custo * l_PeriodoAplicacao);

            decimal l_PercentualIR = ObterPercentualIR(l_PeriodoAplicacao);

            return l_Lucro * l_PercentualIR;            
        }

        public decimal ObterPercentualIR(int a_PeriodoAplicacao)
        {
            if (a_PeriodoAplicacao <= 12)
                return (decimal)1.225;

            if (a_PeriodoAplicacao > 12 && a_PeriodoAplicacao <= 24)
                return (decimal)1.185;

            return (decimal)1.15;
        }

        public void ValidarAplicacao(Aplicacao a_Aplicacao)
        {
            if (a_Aplicacao != null && a_Aplicacao.Valor <= 0)
                throw new ApplicationException("O valor da aplicação deve ser maior que zero (0).");

            if (a_Aplicacao.DataRetirada.HasValue && a_Aplicacao.DataRetirada < a_Aplicacao.DataAplicacao)
                throw new ApplicationException("A data de retirada deve ser posterior à data de aplicação");
        }
    }
}
