using System;
using Aliquota.Application.Common.Mappings;
using Aliquota.Application.Features.FinancialProducts.DTO;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Enums;

namespace Aliquota.Application.Features.Investments.DTOs
{
    public class WithdrawDTO
    {
        public decimal Amount { get; set; }
        public decimal TaxPercentage { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal LiquidIncome { get; set; }
        public decimal Profit { get; set; }
        public decimal InvestedTime { get; set; }
        public DateTime Start { get; set; }
    }
}
