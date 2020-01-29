using Aliquota.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Entities
{
    public class ProgramaFinanceiro
    {
        private readonly CarteiraInvestimentosService _carteiraInvestimentosService;
        private readonly ProdutoFinanceiroService _produtoFinanceiroService;

        public ProgramaFinanceiro(CarteiraInvestimentosService carteiraInvestimentosService, ProdutoFinanceiroService produtoFinanceiroService)
        {
            _carteiraInvestimentosService = carteiraInvestimentosService;
            _produtoFinanceiroService = produtoFinanceiroService;
        }

        public void AplicarInvestimento(ProdutoFinanceiro produtoFinanceiro, decimal valorAplicado)
        {
            CarteiraInvestimentos aplicacaoInvestimento = _carteiraInvestimentosService.AdicionarCarteiraInvestimentos(produtoFinanceiro, DataAplicacao: ,valorAplicado);

            if (aplicacaoInvestimento == null)
                _aplicacaoInvestimentoService.AdicionarAplicacaoInvestimento(valorAplicado, cliente, produtoFinanceiro);
        }

        public Dictionary<string, decimal> ResgatarInvestimentoAplicado(Cliente cliente, ProdutoFinanceiro produtoFinanceiro, decimal PercentualRendimento, DateTime DataResgate)
        {
            AplicacaoInvestimento aplicacaoInvestimento = _aplicacaoInvestimentoService.BuscarClienteProdutoFinanceiro(cliente, produtoFinanceiro);

            if (aplicacaoInvestimento == null)
                throw new ArgumentException("Investimento aplicado não encontrado na plataforma.");
          
            DateTime DataAplicacao = aplicacaoInvestimento.DataAplicacao;
            decimal ValorResgate = aplicacaoInvestimento.ValorAplicacao;

            if (DataResgate < DataAplicacao)
                throw new ArgumentException("Informe uma data de resgate superior a data de aplicação.");

            TimeSpan Intervalo = DataResgate.Date - DataAplicacao.Date;
            decimal Rendimento = CalculoRendimento(ValorResgate, PercentualRendimento, Intervalo);

            decimal IR = CalcularIR(ValorResgate, Intervalo);

            Dictionary<string, decimal> obj = new Dictionary<string, decimal>();
            obj.Add("ValorBruto", ValorResgate + Rendimento);
            obj.Add("IR", IR);
            obj.Add("ValorLiquido", ValorResgate + Rendimento - IR);

            _aplicacaoInvestimentoService.Excluir(aplicacaoInvestimento);

            return obj;
        }

        private decimal CalculoRendimento(decimal ValorResgate, decimal PercentualRendimento, TimeSpan Intervalo)
        {
            double Rendimento = (double)(PercentualRendimento / 100);
            double RendimentoDiario = Math.Pow(1 + Rendimento, 1f / 365f); 

            double ValorResgateRendimento = Math.Pow(RendimentoDiario, Intervalo.TotalDays) * (double)ValorResgate;

            return (decimal)ValorResgateRendimento - ValorResgate;
        }

        private decimal CalcularIR(decimal ValorRendido, TimeSpan Intervalo)
        {
            if (ValorRendido <= 0)
                return 0;

            if (Intervalo.Days <= 365)
                return 0.225m * ValorRendido;
            else if (Intervalo.Days > 365 && Intervalo.Days <= 730)
                return 0.185m * ValorRendido;
            else
                return 0.15m * ValorRendido;
        }
    }
}
