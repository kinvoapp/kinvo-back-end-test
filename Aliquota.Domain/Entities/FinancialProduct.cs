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
            set {
                var specs = JsonSerializer.Deserialize<List<InvestmentEvaluatorSpec>>(value);
                EvaluatorsSpec = specs.Select(spec =>
                    new InvestmentEvaluatorSpec {
                        EvaluatorType = spec.EvaluatorType,
                        Config = InvestmentEvaluatorConfigProvider.GetConfig(((JsonElement) spec.Config).GetRawText(), spec.EvaluatorType),
                    }
                ).ToList();
            }
        }
    }
}