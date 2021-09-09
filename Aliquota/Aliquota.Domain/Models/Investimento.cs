using System;
using System.ComponentModel.DataAnnotations;
using Aliquota.Domain.DataValidation;

namespace Aliquota.Domain.Models
{
    public class Investimento : BaseModel
    {
        #region Propriedades
        public virtual Produto Produto { get; private set; }

        [DateUntilTodayValidation]
        [Display(Name = "Data aplicação")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataInvestimento { get; private set; }

        [Display(Name = "Data resgate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataResgate { get; private set; }

        [Display(Name = "Valor investido")]
        [Required(ErrorMessage = "Por favor, preencha o valor do investimento")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        [Range(0.01, Double.MaxValue, ConvertValueInInvariantCulture = true, ErrorMessage = "Valor inválido")]
        public double ValorInvestido { get; private set; }

        [Display(Name = "Valor resgatado")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        [Range(0.01, Double.MaxValue,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = "Valor inválido")]
        public double? ValorResgatado { get; private set; }

        [Display(Name = "Status")]
        public StatusInvestimento Status { get; private set; }

        [Display(Name = "Imposto recolhido")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        [Range(0.01, Double.MaxValue,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = "Valor inválido")]
        public double? ImpostoRecolhido { get; private set; }

        [Display(Name = "Faixa de imposto")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double? ImpostoFaixaAplicavel { get; private set; }
        #endregion

        // Construtor usado para aplicar migração
        private Investimento() { }

        public Investimento(Produto produto, DateTime dataInvestimento, double valorInvestido)
        {
            this.Produto =  produto;
            this.DataInvestimento = dataInvestimento;
            this.ValorInvestido = valorInvestido;
            this.Status = StatusInvestimento.Investido;
        }

        public void EditInvestimento(Investimento investimento)
        {
            CheckResgatado();

            this.Produto = investimento.Produto;
            this.DataInvestimento = investimento.DataInvestimento;
            this.ValorInvestido = investimento.ValorInvestido;
        }

        public void RescueInvestimento(RendimentoInvest rendimentoInvest)
        {
            CheckResgatado();

            this.DataResgate = rendimentoInvest.DataResgate;
            this.ValorResgatado = rendimentoInvest.ValorMontanteLiquido;
            this.ImpostoRecolhido = rendimentoInvest.ValorImposto;
            this.ImpostoFaixaAplicavel = rendimentoInvest.ImpostoAplicavel;
            this.Status = StatusInvestimento.Resgatado;
        }

        private void CheckResgatado()
        {
            if (this.Status == StatusInvestimento.Resgatado)
            {
                var msg = $"Operação inválida: para realizar o resgate, o Status do investimento não pode ser {StatusInvestimento.Resgatado}";
                throw new InvalidOperationException(msg);
            }
        }
    }
}
