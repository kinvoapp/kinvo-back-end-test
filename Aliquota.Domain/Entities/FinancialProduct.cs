using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json;
using Aliquota.Domain.Services;

namespace Aliquota.Domain.Entities
{
    public class FinancialProduct : EntityBase
    {
        public FinancialProduct() : base() { }

        public string Name { get; set; }

        [NotMapped]
        public List<InvestmentEvaluatorSpec> EvaluatorsSpec { get; set; } // Dont store this

        public string EvaluatorsSpecJson
        { // Store this instead
            get => JsonSerializer.Serialize(EvaluatorsSpec);
            set => EvaluatorsSpec = JsonSerializer.Deserialize<List<InvestmentEvaluatorSpec>>(value);
        }
    }
}