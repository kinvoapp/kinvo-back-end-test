using System;
using System.Collections.Generic;
using System.Text;
using Aliquota.Application.Common.Mappings;
using Aliquota.Application.Features.FinancialProducts.DTO;
using Aliquota.Domain.Entities;

namespace Aliquota.Application.Features.Investments.DTOs
{
    /// <inheritdoc cref="Investment"/>
    public class InvestmentDTO : IMapFrom<Investment>
    {
        public decimal Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Start { get; set; }
        public DateTime? Withdraw { get; set; }
        public decimal FinancialProductId { get; set; }
        public FinancialProductDTO FinancialProduct { get; set; }
    }
}