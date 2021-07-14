using System;
using System.Threading.Tasks;
using Aliquota.Domain.Commands;
using Aliquota.Domain.Contracts.Repositories;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Exceptions;

namespace Aliquota.Domain.Handlers
{
    public class InvestmentHandler
    {
        private readonly IPortfolioRepository portfolioRepository;
        private readonly IFinancialProductRepository financialProductRepository;
        private readonly IInvestmentRepository investmentRepository;

        public InvestmentHandler(
            IPortfolioRepository portfolioRepository,
            IFinancialProductRepository financialProductRepository,
            IInvestmentRepository investmentRepository)
        {
            this.portfolioRepository = portfolioRepository;
            this.financialProductRepository = financialProductRepository;
            this.investmentRepository = investmentRepository;
        }

        public async Task<Investment> HandleAsync(CreateInvestmentCommand command, Guid ownerId)
        {
            var portfolio = await portfolioRepository.GetPortfolioByOwnerIdAsync(ownerId);

            if (command.Value <= 0)
            {
                throw new HandlerException("O valor da aplicação deve ser maior que 0");
            }

            if (command.Value > portfolio.Balance)
            {
                throw new HandlerException("Você não tem saldo suficiente disponível para essa operação");
            }

            var financialProduct = await financialProductRepository.GetProductAsync(command.ProductId);

            var investment = new Investment()
            {
                ApplicationDate = System.DateTimeOffset.Now,
                FinancialProduct = financialProduct,
                InitialValue = command.Value,
                Portfolio = portfolio,
            };

            portfolio.Balance -= investment.InitialValue;
            investmentRepository.Add(investment);

            return investment;
        }
    }
}