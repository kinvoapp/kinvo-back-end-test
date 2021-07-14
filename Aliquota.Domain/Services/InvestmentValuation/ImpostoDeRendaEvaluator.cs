using System;
using System.Collections.Generic;
using System.Linq;
using Aliquota.Domain.Contracts.Services;
using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Services
{
    public class ImpostoDeRendaEvaluatorParams { /* void */ }
    public class ImpostoDeRendaEvaluator : IInvestmentEvaluator
    {
        public ImpostoDeRendaEvaluator(ImpostoDeRendaEvaluatorParams config)
        {

        }

        public void Evaluate(Investment investment, List<InvestmentEvaluationComponent> evaluations)
        {
            var profit = evaluations.Any()? evaluations.Select(e => e.Value).Aggregate((acc, v) => acc + v) : 0;

            TimeSpan timePassed = (investment.RedemptionDate ?? DateTimeOffset.Now) - investment.ApplicationDate;
            var yearsPassed = (int) (timePassed.Days / 365);

            var evaluation = new InvestmentEvaluationComponent
            {
                Name = "Imposto de renda",
                Alias = "IR",
            };

            if (yearsPassed < 1)
            {
                evaluation.Value = profit * 0.225;
            }
            else if (yearsPassed < 2)
            {
                evaluation.Value = profit * 0.185;
            }
            else
            {
                evaluation.Value = profit * 0.15;
            }

            evaluation.Value *= -1; // IR is an abatement
            evaluations.Add(evaluation);
        }
    }
}