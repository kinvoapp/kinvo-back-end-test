using System.Collections.Generic;
using System.Linq;
using Aliquota.Domain.Entities;
using Xunit;

namespace Aliquota.Domain.Test.Entities
{
    public class ImpostoDeRendaEvaluatorTest
    {
        [Fact]
        public void Evaluate_ShouldCalculateProperly1()
        {
            var evaluator = new ImpostoDeRendaEvaluator(new ImpostoDeRendaEvaluatorParams { });

            var investment = new Investment
            {
                InitialValue = 1000,
                ApplicationDate = System.DateTimeOffset.Now.AddMonths(-6),
            };

            var evaluations = new List<InvestmentEvaluationComponent>();
            evaluations.Add(new InvestmentEvaluationComponent {
                Alias = "Test",
                Name = "Fake Test Evaluation",
                Value = 20,
            });
            
            evaluator.Evaluate(investment, evaluations);

            Assert.NotNull(evaluations.FirstOrDefault(e => e.Value - (20 * 0.775) < 0.001));
        }

        [Fact]
        public void Evaluate_ShouldCalculateProperly2()
        {
            var evaluator = new ImpostoDeRendaEvaluator(new ImpostoDeRendaEvaluatorParams { });

            var investment = new Investment
            {
                InitialValue = 1000,
                ApplicationDate = System.DateTimeOffset.Now.AddMonths(-18),
            };

            var evaluations = new List<InvestmentEvaluationComponent>();
            evaluations.Add(new InvestmentEvaluationComponent {
                Alias = "Test",
                Name = "Fake Test Evaluation",
                Value = 30,
            });
            
            evaluator.Evaluate(investment, evaluations);

            Assert.NotNull(evaluations.FirstOrDefault(e => e.Value - (30 * 0.815) < 0.001));
        }

        [Fact]
        public void Evaluate_ShouldCalculateProperly3()
        {
            var evaluator = new ImpostoDeRendaEvaluator(new ImpostoDeRendaEvaluatorParams { });

            var investment = new Investment
            {
                InitialValue = 1000,
                ApplicationDate = System.DateTimeOffset.Now.AddMonths(-18),
            };

            var evaluations = new List<InvestmentEvaluationComponent>();
            evaluations.Add(new InvestmentEvaluationComponent {
                Alias = "Test",
                Name = "Fake Test Evaluation",
                Value = 100,
            });
            
            evaluator.Evaluate(investment, evaluations);

            Assert.NotNull(evaluations.FirstOrDefault(e => e.Value - (100 * 0.85) < 0.001));
        }
    }
}