using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Aliquota.Domain.Utils;

namespace Aliquota.Domain.Entity
{
    [Table("share")]
    public class Share
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("fantasy_name")]
        public string FantasyName { get; set; }

        [Column("value")]
        public decimal Value { get; set; }

        [Column("application_date")]
        public DateTime ApplicationDate { get; set; }

        [Column("withdraw_date")]
        public DateTime? WithdrawDate { get; set; }

        public decimal AfterTaxValue { 
            get
            {
                if(WithdrawDate?.Year - ApplicationDate.Year <= 1)
                {
                    return Value - Value * Constants.OneYearFactor;
                }
                else if(WithdrawDate?.Year - ApplicationDate.Year > 1 && WithdrawDate?.Year - ApplicationDate.Year <= 2)
                {
                    return Value - Value * Constants.BetweenOneAndTwoYearsFactor;
                }
                else
                {
                    return Value - Value * Constants.PlusTwoYearsFactor;
                }
            }
        }
    }
}
