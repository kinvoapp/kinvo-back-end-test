using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Aliquota.Domain
{
    public class Application
    {
        const string errorMessageRange = "'{0}' deve ser maior que zero.";
        const string errorMessageRequired = "'{0}' deve ser preenchido.";

        public int Id { get; set; }

        [Required(ErrorMessage = errorMessageRequired)]
        [Display(Name = "Valor Investido")]
        [DataType(DataType.Currency)]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = errorMessageRange)]
        public decimal InvestedValue { get; set; }
        [Display(Name = "Lucro")]
        [DataType(DataType.Currency)]
        public decimal ProfitValue { get; set; }
        [Display(Name = "Valor Total")]
        [DataType(DataType.Currency)]
        public decimal TotalValue { get; set; }
        [Display(Name = "Valor Retido")]
        [DataType(DataType.Currency)]
        public decimal WithholdedValue { get; set; }

        [Required(ErrorMessage = errorMessageRequired)]
        [Display(Name = "Juros ao mês")]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = errorMessageRange)]
        [DisplayFormat(DataFormatString = "number")]
        public decimal MonthlyInterestRate { get; set; }
        [Required(ErrorMessage = errorMessageRequired)]
        [Display(Name = "Meses para o resgate")]
        [Range(1, int.MaxValue, ErrorMessage = "'{0}' deve ser um número inteiro maior que zero.")]
        public int ExpectedMonthlyPeriod { get; set; }

        [Display(Name = "Data de aplicação")]
        [DataType(DataType.Date)]
        public DateTime ApplyDate { get; set; }
        [Display(Name = "Data de resgate")]
        [DataType(DataType.Date)]
        public DateTime WithdrawDate { get; set; }

        public void OnNewEntry()
        {
            ApplyDate = DateTime.Now;
            WithdrawDate = ApplyDate.AddMonths(ExpectedMonthlyPeriod);
            ProfitValue =
                (InvestedValue * Transactions.CalculateProfitability(ExpectedMonthlyPeriod, (double)MonthlyInterestRate)) - InvestedValue;
            TotalValue = InvestedValue + ProfitValue;
            WithholdedValue = ProfitValue * Transactions.CalculateIncomeTax((WithdrawDate - ApplyDate).Days / 365f);
        }
    }
}
