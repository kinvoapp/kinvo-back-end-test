using System.Collections.Generic;
using System.Linq;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Services;
using Xunit;

namespace Aliquota.Domain.Test.Entities
{
    public class ConstantMultiplierEvaluatorTest
    {
        [Fact]
        public void Evaluate_ShouldConfigureAndCalculateProperly1()
        {
            var evaluator = new ConstantMultiplierEvaluator(new ConstantMultiplierEvaluatorParams
            {
                Multiplier = 100.1 / 100, // 100.1%
                PeriodMinutes = 24 * 60, // 1 day
            });

            var investment = new Investment
            {
                InitialValue = 1000, // $10
                ApplicationDate = System.DateTimeOffset.Now.AddDays(-1),
            };

            var evaluations = new List<InvestmentEvaluationComponent>();
            evaluator.Evaluate(investment, evaluations);

            Assert.NotNull(evaluations.FirstOrDefault(e => e.Value - (1000 * 100.1 / 100 - 1000) < 0.001));
        }

        [Fact]
        public void Evaluate_ShouldConfigureAndCalculateProperly2()
        {
            var evaluator = new ConstantMultiplierEvaluator(new ConstantMultiplierEvaluatorParams
            {
                Multiplier = 100.1 / 100, // 100.1%
                PeriodMinutes = 24 * 60, // 1 day
            });

            var investment = new Investment
            {
                InitialValue = 1000,
                ApplicationDate = System.DateTimeOffset.Now.AddDays(-2),
            };

            var evaluations = new List<InvestmentEvaluationComponent>();
            evaluator.Evaluate(investment, evaluations);

            Assert.NotNull(evaluations.FirstOrDefault(e => e.Value - (1000 * 100.1 / 100 * 100.1 / 100 - 1000) < 0.001));
        }
    }
}