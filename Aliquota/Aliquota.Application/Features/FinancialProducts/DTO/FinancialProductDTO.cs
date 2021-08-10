using System;
using System.Collections.Generic;
using System.Text;
using Aliquota.Domain.Entities;
using Aliquota.Application.Common.Mappings;
using Aliquota.Domain.Enums;

namespace Aliquota.Application.Features.FinancialProducts.DTO
{
    ///<inheritdoc cref="Models.FinancialProduct"/>
    public class FinancialProductDTO : IMapFrom<FinancialProduct>
    {
        public decimal Id { get; set; }
        public string Name { get; set; }

        public decimal MinimalInvestedAmount { get; set; }
        public decimal MonthlyIncome { get; set; }

        public Profitability Profitability { get; set; }

        public Deadline Deadline { get; set; }
    }
}
