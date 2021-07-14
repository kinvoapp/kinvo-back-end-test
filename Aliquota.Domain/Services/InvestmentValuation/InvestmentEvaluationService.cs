using System.Collections.Generic;
using System.Linq;
using Aliquota.Domain.Contracts.Services;
using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Services
{
    public class InvestmentEvaluationService
    {
        public IInvestmentEvaluator GetInvestmentEvaluator(InvestmentEvaluatorTypes types, object configuration)
        {
            return types switch {
                InvestmentEvaluatorTypes.ConstantMultiplier => 
                    new ConstantMultiplierEvaluator((ConstantMultiplierEvaluatorParams) configuration),
                InvestmentEvaluatorTypes.ImpostoDeRenda =>
                    new ImpostoDeRendaEvaluator((ImpostoDeRendaEvaluatorParams) configuration),
                _ => 
                    new ConstantMultiplierEvaluator((ConstantMultiplierEvaluatorParams) configuration),
            };
        }

        public List<InvestmentEvaluationComponent> Evaluate(Investment investment)
        {
            var evaluations = new List<InvestmentEvaluationComponent>();
            
            var evaluators = investment.FinancialProduct.EvaluatorsSpec.Select(spec => GetInvestmentEvaluator(spec.EvaluatorType, spec.Config));
            foreach(var evaluator in evaluators) 
            {
                evaluator.Evaluate(investment, evaluations);
            }

            return evaluations;
        }
    }
}