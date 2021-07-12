using Aliquota.Domain.Entities;
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

        public FinancialProductModel ToModel(FinancialProduct financialProductModel)
        {
            return new FinancialProductModel
            {
                Name = financialProductModel.Name,
            };
        }
    }
}