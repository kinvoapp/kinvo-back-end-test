using System;
using Aliquota.Data.Entity;

namespace Aliquota.Domain.DTO
{
    public class ApplicationDTO
    {
        public long Id { get; set; }

        public string ApplicationCode { get; set; }

        public long ClientId { get; set; }

        public DateTime ApplicationDate { get; set; }

        public DateTime? WithdrawDate { get; set; }

        public decimal ApplicationValue { get; set; }

        public decimal WithdrawValue { get; set; }

        public ApplicationDTO() {}
        
        public static explicit operator ApplicationDTO(Application application)
        {
            return new ApplicationDTO() 
            { 
                ApplicationCode = application.ApplicationCode, 
                ApplicationDate = application.ApplicationDate,
                ApplicationValue = application.ApplicationValue,
                WithdrawDate = application.WithdrawDate,
                WithdrawValue = application.WithdrawValue 
            };
        }

    }
}