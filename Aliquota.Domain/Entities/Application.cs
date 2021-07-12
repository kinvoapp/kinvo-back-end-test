using System;
using Aliquota.Domain.DTO;

namespace Aliquota.Domain.Entities
{
    public class Application
    {
        public int Id { get; set; }
        public decimal ApplicationValue { get; set; }
        public DateTime ApplicationDate { get; set; }
        public decimal? WithdrawValue { get; set; }
        public DateTime? WithdrawDate { get; set; }
        public virtual Client Client { get; set; }
        public int ClientId { get; set; }
        public bool IsActive { get; set; }


        public Application()
        {

        }

        public static explicit operator Application(ApplicationDTO dto)
        {
            return new Application()
            {
                ApplicationValue = dto.ApplicationValue,
                ClientId = dto.ClientId,
                ApplicationDate = dto.ApplicationDate,
                IsActive = true
            };
        }

        public static explicit operator Application(ResponseApplicationDTO dto)
        {
            return new Application()
            {
                Id = dto.ApplicationId,
                ClientId = dto.ClientId,
                ApplicationValue = dto.ApplicationValue,
                ApplicationDate = dto.ApplicationDate,
                IsActive = dto.IsActive,
                WithdrawDate = dto.WithdrawDate,
                WithdrawValue = dto.WithdrawValue
            };
        }
    }
}