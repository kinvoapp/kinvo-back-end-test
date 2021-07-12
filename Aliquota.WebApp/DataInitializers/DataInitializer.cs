using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Services;

namespace Aliquota.WebApp.DataInitializers
{
    public class DataInitializer
    {
        private readonly FinancialProductInitializer financialProductInitializer;
        private readonly UserInitializer userInitializer;
        private readonly PortfolioInitializer portfolioInitializer;

        public DataInitializer(
            FinancialProductInitializer financialProductInitializer,
            UserInitializer userInitializer,
            PortfolioInitializer portfolioInitializer)
        {
            this.financialProductInitializer = financialProductInitializer;
            this.userInitializer = userInitializer;
            this.portfolioInitializer = portfolioInitializer;
        }

        public async Task EnsureDataExists()
        {
            var users = getDefaultUsers();
            var products = getDefaultProducts();
            
            await financialProductInitializer.EnsureFinancialProductsExist(products);
            await userInitializer.EnsureUsersExistAndRecreate(users);
            await portfolioInitializer.EnsurePortfoliosExist(getDefaultPortfolios(users, products.FirstOrDefault()));
        }

        private List<FinancialProduct> getDefaultProducts()
        {
            var product = new FinancialProduct()
            {
                Name = "CDB POS",
                EvaluatorsSpec = new List<InvestmentEvaluatorSpec>() {
                    new InvestmentEvaluatorSpec {
                        EvaluatorType = InvestmentEvaluatorTypes.ConstantMultiplier,
                        Config = new ConstantMultiplierEvaluatorParams {
                            Multiplier = 105/100, // 105%
                            PeriodMinutes = 30*24*60, // ~ 1 month
                        }
                    },
                    new InvestmentEvaluatorSpec {
                        EvaluatorType = InvestmentEvaluatorTypes.ImpostoDeRenda,
                        Config = new ImpostoDeRendaEvaluatorParams(),
                    },
                },
            };

            return new List<FinancialProduct>() { product };
        }

        private List<User> getDefaultUsers()
        {
            var user = new User("john.nash@email.com", "John Nash");
            user.SetPassword("Equilibrated123");

            return new List<User>() { user };
        }

        private List<Portfolio> getDefaultPortfolios(List<User> defaultUsers, FinancialProduct defaultFinancialProduct)
        {
            return defaultUsers.Select(user =>
            {
                var portfolio = new Portfolio()
                {
                    Balance = 500.0,
                    Owner = user,
                    Investments = new List<Investment>() {
                        new Investment() {
                            ApplicationDate = DateTimeOffset.Now.AddMonths(-6),
                            FinancialProduct = defaultFinancialProduct,
                            InitialValue = 200.0,
                        },
                        new Investment() {
                            ApplicationDate = DateTimeOffset.Now.AddMonths(-18),
                            FinancialProduct = defaultFinancialProduct,
                            InitialValue = 200.0,
                        },
                        new Investment() {
                            ApplicationDate = DateTimeOffset.Now.AddMonths(-30),
                            FinancialProduct = defaultFinancialProduct,
                            InitialValue = 200.0,
                        },
                    },
                };

                portfolio.Investments.ForEach(i => i.Portfolio = portfolio);
                return portfolio;
            }).ToList();
        }
    }
}