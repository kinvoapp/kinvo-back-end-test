using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Services {
    public enum InvestmentEvaluatorTypes {
        ConstantMultiplier = 1,
        ImpostoDeRenda = 2,
    }

    public class InvestmentEvaluatorSpec {
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
}