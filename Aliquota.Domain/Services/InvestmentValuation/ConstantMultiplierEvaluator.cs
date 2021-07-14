using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Aliquota.Domain.Contracts.Services;
using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Services
{
    public class ConstantMultiplierEvaluatorParams
    {
        [JsonPropertyName("p")]
        public int PeriodMinutes { get; set; } // The value will be multiplied at every PeriodMinutes minutes

        [JsonPropertyName("m")]
        public double Multiplier { get; set; } // The value will be multiplied by Multiplier
    }

    public class ConstantMultiplierEvaluator : IInvestmentEvaluator
    {
        private readonly int periodMinutes;
        private readonly double multiplier;
        public ConstantMultiplierEvaluator(ConstantMultiplierEvaluatorParams config)
        {
            periodMinutes = config.PeriodMinutes;
            multiplier = config.Multiplier;
        }

        public void Evaluate(Investment investment, List<InvestmentEvaluationComponent> evaluations)
        {
            var minutesPassed = ((investment.RedemptionDate ?? DateTimeOffset.Now) - investment.ApplicationDate).TotalMinutes;
            var currentValue = investment.InitialValue * Math.Pow(multiplier, (int) minutesPassed / periodMinutes);
            evaluations.Add(new InvestmentEvaluationComponent {
                Name = "Valorização",
                Alias = "Valorização",
                Value = currentValue - investment.InitialValue,
            });
        }
    }
}