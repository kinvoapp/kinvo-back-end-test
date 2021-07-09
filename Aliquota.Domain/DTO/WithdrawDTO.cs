using Aliquota.Domain.Entities;
using System;

namespace Aliquota.Domain.DTO
{
    public class WithdrawDTO
    {
        public string FantasyName { get; set; }
        public decimal ApplicationValue { get; set; }
        public decimal? WithdrawValue { get; set; }
        public decimal TaxPercentage { get; set; }
        public decimal TaxValue { get; set; }
        public DateTime ApplicationDate { get; private set; }
        public DateTime? WithdrawDate { get; private set; }

        public static explicit operator WithdrawDTO(Application application)
        {
            return new WithdrawDTO()
            {
                FantasyName = application.Client.FantasyName,
                ApplicationDate = application.ApplicationDate,
                ApplicationValue = application.ApplicationValue,
                WithdrawDate = application.WithdrawDate,
                WithdrawValue = application.WithdrawValue
            };
        }
    }
}