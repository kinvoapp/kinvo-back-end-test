using System;
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Web.Mvc;

namespace Aliquota.Application.Dtos
{
    public class FinancialApplicationDto
    {

        //public virtual Client Client { get; set; }
        //public virtual Product Product { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        [DataType(DataType.Date)]
        public DateTime DateApplication { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "O investimento deve ser maior que zero")]
        [DisplayFormat(DataFormatString = "{0,c}")]
        public decimal Investiment { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "A taxa de rendimento deve ser maior que zero")]
        public decimal YieldRate { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Compare("CheckDateRescue", 
        ErrorMessage = "A data de resgate não pode ser menor que a data da aplicação")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime DateRescue { get; set; }
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public DateTime CheckDateRescue
        {
            get
            {
                if (this.DateRescue >= this.DateApplication)
                {
                    return this.DateRescue;
                }
                return this.DateApplication;
            }

        }
        public decimal ROI
        {
            get
            {
                decimal amount = 0;
                if (this.DateRescue > this.DateApplication)
                {
                    var years = (int)((this.DateRescue.Subtract(this.DateApplication).TotalDays) / 365);
                    var profit = years > 0 ? 
                        this.Investiment * years * (this.YieldRate / 100) 
                        : 0;
                    var tax = years > 0 ? GetTax(years) : 0;
                    var discount = profit * tax;
                    amount = this.Investiment + profit - discount;
                  
                    return amount;
                }
                               
                return this.Investiment;
            }
        }
        private decimal GetTax(int years)
        {
            decimal tax = 0;
            switch (years)
            {
                case int y when years <= 1:
                    tax = decimal.Parse("22.5");
                    break;
                case int y when years > 1 && years <= 2:
                    tax = decimal.Parse("18.5");
                    break;
                case int y when years > 2:
                    tax = decimal.Parse("15.0");
                    break;
                default:
                    tax = 0;
                    break;
            }
            return (tax / 1000);
        }
    }
}
