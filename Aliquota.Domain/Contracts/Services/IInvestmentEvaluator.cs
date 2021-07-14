using System.Collections.Generic;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Services;

namespace Aliquota.Domain.Contracts.Services {
    public interface IInvestmentEvaluator {
        void Evaluate(Investment investment, List<InvestmentEvaluationComponent> evaluations);
    }
}