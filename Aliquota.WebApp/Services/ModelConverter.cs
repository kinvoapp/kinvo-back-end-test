using System.Collections.Generic;
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
                ApplicationDate = investment.ApplicationDate,
                FinancialProduct = ToModel(investment.FinancialProduct),
                InitialValue = investment.InitialValue,
            };
        }

        public InvestmentFullModel ToFullModel(Investment investment, List<InvestmentEvaluationComponent> evaluations)
        {
            return new InvestmentFullModel
            {
                ApplicationDate = investment.ApplicationDate,
                FinancialProduct = ToModel(investment.FinancialProduct),
                InitialValue = investment.InitialValue,
                Evaluations = evaluations.ConvertAll(e => ToModel(e)),
                RedemptionDate = investment.RedemptionDate,
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