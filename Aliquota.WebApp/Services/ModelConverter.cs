using System.Collections.Generic;
using System.Linq;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Services;
using Aliquota.WebApp.Models;

namespace Aliquota.WebApp.Services
{
    public class ModelConverter
    {
        public UserModel ToModel(User user)
        {
            return new UserModel
            {
                Email = user.Email,
                FullName = user.FullName,
            };
        }

        public PortfolioModel ToModel(Portfolio portfolio)
        {
            return new PortfolioModel
            {
                Balance = portfolio.Balance,
                Investments = portfolio.Investments.ConvertAll(i => ToModel(i)),
            };
        }

        public InvestmentModel ToModel(Investment investment)
        {
            return new InvestmentModel
            {
                Id = investment.Id,
                ApplicationDate = investment.ApplicationDate,
                RedemptionDate = investment.RedemptionDate,
                FinancialProduct = ToModel(investment.FinancialProduct),
                InitialValue = investment.InitialValue,
            };
        }

        public InvestmentFullModel ToFullModel(Investment investment, List<InvestmentEvaluationComponent> evaluations)
        {
            return new InvestmentFullModel
            {
                Id = investment.Id,
                ApplicationDate = investment.ApplicationDate,
                RedemptionDate = investment.RedemptionDate,
                FinancialProduct = ToModel(investment.FinancialProduct),
                InitialValue = investment.InitialValue,
                CurrentValue = evaluations.Select(e => e.Value).Aggregate((acc, v) => acc + v) + investment.InitialValue,
                Evaluations = evaluations.ConvertAll(e => ToModel(e)),
            };
        }

        public InvestmentEvaluationModel ToModel(InvestmentEvaluationComponent evaluationComponent) 
        {
            return new InvestmentEvaluationModel
            {
                Name = evaluationComponent.Name,
                Alias = evaluationComponent.Alias,
                Value = evaluationComponent.Value,
            };
        }

        public FinancialProductModel ToModel(FinancialProduct financialProductModel)
        {
            return new FinancialProductModel
            {
                Name = financialProductModel.Name,
            };
        }
    }
}