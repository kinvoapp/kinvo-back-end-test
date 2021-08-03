using System;
using System.Threading.Tasks;
using Aliquota.Core.DomainObjects;
using Aliquota.Domain.Interfaces;

namespace Aliquota.Domain.Services
{
    public class CalculoDoImpostoDeRendaService : ICalculoDoImpostoDeRendaService
    {
        private readonly IProdutoFinanceiroRepository _produtoFinanceiroRepository;

        public CalculoDoImpostoDeRendaService(IProdutoFinanceiroRepository produtoFinanceiroRepository)
        {
            _produtoFinanceiroRepository = produtoFinanceiroRepository;
        }
        public async Task<double> Calcular(Guid produtoFinanceiroId)
        {
            var produtoFinanceiro = await _produtoFinanceiroRepository.ObterPeloId(produtoFinanceiroId);

            if(produtoFinanceiro == null)
            {
                throw new DomainException("Produto financeiro não encontrado");
            }

            var tempoDeAplicacao = produtoFinanceiro.CalcularTempoDeAplicacao();
            var anoComercial = 360;
            var tempoDeAplicacaoEmDias = tempoDeAplicacao.TotalDays;

            if (tempoDeAplicacaoEmDias < anoComercial)
            {
                return produtoFinanceiro.Lucro * 0.225;
            }
            else if (tempoDeAplicacaoEmDias < 2 * anoComercial)
            {
                return produtoFinanceiro.Lucro * 0.185;
            }
            else
            {
                return produtoFinanceiro.Lucro * 0.15;
            }
        }
    }
}