using System;
using Aliquota.Domain.Entity;

namespace Aliquota.Core.DTO
{
    public class WithDrawApplicationDto
    {
        public string FantasyName { get; set; }
        public decimal Value { get; set; }
        public static explicit operator WithDrawApplicationDto(Share share) =>
            new WithDrawApplicationDto()
            {
                FantasyName = share.FantasyName,
                Value = share.AfterTaxValue
            };
    }
}
