
using Income.Tax.Willian.Santos.Kinvo.Domain.Entities.Relationships;
using Income.Tax.Willian.Santos.Kinvo.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Income.Tax.Willian.Santos.Kinvo.Domain.Entities
{
    public class ApplicationIT: Entity
    {
        [Required]
        [Range(1,999999)]
        [Column(TypeName = "float")]
        [Display(Name = "Valor aplicado")]
        public float Value { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        [Display(Name = "Data da aplicação")]
        public DateTime ContributionTime { get; set; }

        public ApplicationTimeAction TimeAction { get; set; }
        public IncomeTaxInterest Interest { get; set; }

        public void SetValue(float value)
        {
            Value = value;
        }

        public void SetContributionTime(DateTime contributionTime)
        {
            ContributionTime = contributionTime;
        }

        public void SetTimeAction(int quantityMonths, int quantityDays)
        {
            TimeAction = new ApplicationTimeAction(quantityMonths, quantityDays);
        }

        public void SetProfitWithInterest(float profitWithInterest)
        {
            Interest = new IncomeTaxInterest(Interest?.FullProfit, profitWithInterest);
        }
        
        public void SetFullProfit(float fullProfit)
        {
            Interest = new IncomeTaxInterest(fullProfit, Interest?.ProfitWithInterest);
        }
    }
}
