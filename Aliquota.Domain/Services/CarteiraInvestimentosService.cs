using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Aliquota.Domain.Services
{
    public class CarteiraInvestimentosService
    {
        private CarteiraInvestimentos carteiraInvestimentos;

        public CarteiraInvestimentosService(CarteiraInvestimentos carteiraInvestimentos)
        {
            this.carteiraInvestimentos = carteiraInvestimentos;
        }

        public CarteiraInvestimentos AdicionarCarteiraInvestimentos(ProdutoFinanceiro produtoFinanceiro, DateTime DataAplicacao, decimal ValorAplicacao)
        {
            this.ValidacaoAdicionarCarteiraInvestimentos(produtoFinanceiro, ValorAplicacao);

            CarteiraInvestimentos carteiraInvestimentos;

            carteiraInvestimentos = new CarteiraInvestimentos
            {
                ProdutoFinanceiro = produtoFinanceiro,
                ValorAplicado = ValorAplicacao,
                DataAplicado = DateTime.Now.Date
            };

            return carteiraInvestimentos;
        }

        private void ValidacaoAdicionarCarteiraInvestimentos(ProdutoFinanceiro produtoFinanceiro, decimal ValorAplicacao)
        {
            if (ValorAplicacao <= 0)
                throw new ArgumentException("Informar o valor da aplicação.");

            if (produtoFinanceiro == null)
                throw new ArgumentException("Informar o produto financeiro.");
        }

        public CarteiraInvestimentos ResgatarCarteiraInvestimentos(CarteiraInvestimentos carteiraInvestimentos, DateTime DataResgate, decimal PercentualRendimento)
        {
            if(carteiraInvestimentos == null)
                throw new ArgumentException("Investimento aplicado não encontrado na plataforma.");

            DateTime DataAplicado = _carteiraInvestimentos.DataAplicado;
            decimal ValorBruto = _carteiraInvestimentos.ValorBruto;

            if (DataResgate < DataAplicado)
                throw new ArgumentException("Informe uma data de resgate superior a data de aplicação.");

            TimeSpan Intervalo = DataResgate.Date - DataAplicado.Date;
            decimal Rendimento = CalculoRendimento(ValorBruto, PercentualRendimento, Intervalo);

            decimal IR = CalcularIR(ValorBruto, Intervalo);

            Dictionary<string, decimal> obj = new Dictionary<string, decimal>();
            obj.Add("ValorBruto", ValorBruto + Rendimento);
            obj.Add("IR", IR);
            obj.Add("ValorLiquido", ValorBruto + Rendimento - IR);

            return _carteiraInvestimentos;
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