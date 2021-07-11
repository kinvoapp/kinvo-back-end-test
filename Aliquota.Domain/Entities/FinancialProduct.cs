using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json;

namespace Aliquota.Domain.Entities
{
    public class FinancialProduct : EntityBase
    {
        public FinancialProduct() : base() { }

        public string Name { get; set; }

        [NotMapped]
        public List<InvestmentEvaluatorCommand> Evaluators { get; set; } // Dont store this

        public string EvaluatorsJson { // Store this instead
            get => JsonSerializer.Serialize(Evaluators);
            set => JsonSerializer.Deserialize<List<InvestmentEvaluatorCommand>>(value);
        }
    }
}