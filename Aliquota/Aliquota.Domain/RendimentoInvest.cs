using Aliquota.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain
{
    public class RendimentoInvest
    {
        public Investimento Investimento { get; private set; }

        [Display(Name = "Dias investido")]
        public int TotalDiasInvestido { get; private set; }

        [Display(Name = "Rendimento")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double ValorRendimento { get; private set; }

        [Display(Name = "Valor líquido")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double ValorMontanteLiquido { get; private set; }

        [Display(Name = "Valor de IR")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double ValorImposto { get; private set; }

        [Display(Name = "IR sobre o lucro")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double ImpostoAplicavel { get; private set; }

        [Display(Name = "Data de resgate")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataResgate { get; private set; }

        public RendimentoInvest(Investimento investimento)
        {
            
            this.Investimento = investimento;

            if (this.Investimento.Status == StatusInvestimento.Investido)
            {
                this.DataResgate = DateTime.Today;
                AtualizarInvestimento();
            }
            else
            {
                this.DataResgate = (DateTime)this.Investimento.DataResgate;
                CarregaInvestimento();
            }
        }

        private void AtualizarInvestimento()
        {
            this.TotalDiasInvestido = CalculadoraInvest.DiasEntreDatas(this.Investimento.DataInvestimento, DateTime.Today);

            var montanteBruto = CalculadoraInvest.RendimentoDoInvestimento(this.Investimento, DateTime.Today);

            this.ValorRendimento = montanteBruto - this.Investimento.ValorInvestido;
            this.ValorRendimento = Math.Round(this.ValorRendimento, 2, MidpointRounding.AwayFromZero);

            var mesesInvestido = CalculadoraInvest.MesesEntreDatas(this.Investimento.DataInvestimento, DateTime.Today);

            this.ValorImposto = CalculadoraInvest.ImpostoDeRendaSobreLucro(this.ValorRendimento, mesesInvestido);

            this.ImpostoAplicavel = (CalculadoraInvest.ValorTributacao(mesesInvestido)) * 100;

            this.ValorMontanteLiquido =  montanteBruto - this.ValorImposto;
        }

        private void CarregaInvestimento()
        {
            this.TotalDiasInvestido = CalculadoraInvest.DiasEntreDatas(this.Investimento.DataInvestimento, (DateTime)this.Investimento.DataResgate);

            this.ValorRendimento = (double)(this.Investimento.ValorResgatado + this.Investimento.ImpostoRecolhido);

            this.ValorImposto = (double)this.Investimento.ImpostoRecolhido;

            this.ImpostoAplicavel = (double)this.Investimento.ImpostoFaixaAplicavel;
            
            this.ValorMontanteLiquido = (double)this.Investimento.ValorResgatado;
        }

    }
}
