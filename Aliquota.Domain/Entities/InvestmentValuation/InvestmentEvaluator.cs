using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Aliquota.Domain.Entities {
    public enum InvestmentEvaluatorTypes {
        ConstantMultiplier = 1,
        ImpostoDeRenda = 2,
    }

    public class InvestmentEvaluatorCommand {
        [JsonIgnore]
        public InvestmentEvaluatorTypes EvaluatorType { get; set; }

        [JsonPropertyName("N")]
        public string EvaluatorName { 
            get => EvaluatorType.ToString();
            set => EvaluatorType = (InvestmentEvaluatorTypes) Enum.Parse(typeof(InvestmentEvaluatorTypes), value);
        }
        
        [JsonPropertyName("P")]
        public object Config { get; set; }
    }

    public class InvestmentEvaluationComponent {
        public string Name { get; set; }
        public string Alias { get; set; }
        public double Value { get; set; } // Negative for abatements
    }

    public interface IInvestmentEvaluator {
        void Evaluate(Investment investment, List<InvestmentEvaluationComponent> evaluations);
    }
}