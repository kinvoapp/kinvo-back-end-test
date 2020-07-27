using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aliquota.Domain.Entities
{
    public class Aplicacao
    {
        public const decimal TaxaImpostoAte1Ano = 22.5m;
        public const decimal TaxaImpostoAte2Anos = 18.5m;
        public const decimal TaxaImpostoMaiorQue2Anos = 15m;
        public const decimal TaxaRendimentoPorAno = 0.02m;

        private Aplicacao() {
            Id = Guid.NewGuid();
        }

        public static Aplicacao Criar(decimal valor, DateTime data) {

            var aplicacao = new Aplicacao();

            aplicacao.Data = data;
            aplicacao.Valor = valor;
            aplicacao.ValorCorrigido = valor;
            aplicacao.PercentualRendimentoMes = TaxaRendimentoPorAno / 12M;
            aplicacao.TaxaImpostoRenda = TaxaImpostoAte1Ano;
            aplicacao.Resgatado = false;

            return aplicacao;
        }

        public Guid Id { get; set; }

        public decimal Valor { get; set; }

        public decimal ValorCorrigido { get; set; }

        public decimal PercentualRendimentoMes { get; set; }

        public DateTime Data { get; set; }

        public decimal TaxaImpostoRenda { get; set; }

        public Guid ResgateId { get; set; }

        public Resgate Resgate { get; set; }

        public bool Resgatado { get; set; }

        public bool EValida() => Valor > 0 && Data > DateTime.MinValue;

        public bool PodeResgatar(DateTime dataResgate)
        {
            return dataResgate > Data && ResgateId == Guid.Empty;
        }

        public void Resgatar(DateTime dataResgate)
        {
            var totalMeses = (dataResgate.Month + dataResgate.Year * 12) - (Data.Month + Data.Year * 12);
           
            foreach (int i in Enumerable.Repeat(1, totalMeses))
            {
                CalcularRendimento();
            }

            var valorImposto = CalcularImposto(dataResgate);
            ValorCorrigido = Math.Round(ValorCorrigido, 2);
            Resgate = Resgate.Criar(dataResgate, ValorCorrigido, valorImposto);
            Resgatado = true;
        }

        private decimal CalcularImposto(DateTime dataResgate)
        {
            var anosInvetimento = dataResgate.Year - Data.Year;
            var totalRendimento = ValorCorrigido - Valor;

            if (anosInvetimento <= 1)
            {
                TaxaImpostoRenda = TaxaImpostoAte1Ano;
              
            }
            else if (anosInvetimento <= 2)
            {
                TaxaImpostoRenda = TaxaImpostoAte2Anos;
            } 
            else
            {
                TaxaImpostoRenda = TaxaImpostoMaiorQue2Anos;
            }

            return (TaxaImpostoRenda / 100) * totalRendimento;
        }

        private void CalcularRendimento()
        {
            ValorCorrigido += ValorCorrigido * PercentualRendimentoMes;
        }
    }
}
