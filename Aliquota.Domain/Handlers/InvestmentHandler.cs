using System;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.Domain.Commands;
using Aliquota.Domain.Contracts.Repositories;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Exceptions;
using Aliquota.Domain.Services;

namespace Aliquota.Domain.Handlers
{
    public class InvestmentHandler
    {
        private readonly IPortfolioRepository portfolioRepository;
        private readonly IFinancialProductRepository financialProductRepository;
        private readonly IInvestmentRepository investmentRepository;
        private readonly InvestmentEvaluationService investmentEvaluationService;

        public InvestmentHandler(
            IPortfolioRepository portfolioRepository,
            IFinancialProductRepository financialProductRepository,
            IInvestmentRepository investmentRepository, 
            InvestmentEvaluationService investmentEvaluationService)
        {
            this.portfolioRepository = portfolioRepository;
            this.financialProductRepository = financialProductRepository;
            this.investmentRepository = investmentRepository;
            this.investmentEvaluationService = investmentEvaluationService;
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

            if(financialProduct == null) 
            {
                throw new HandlerException("O produto financeiro solicitado não existe");
            }

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

        public async Task<Investment> HandleAsync(RedemptInvestmentCommand command, Guid requesterId)
        {
            var investment = await investmentRepository.GetInvestmentAsync(command.InvestmentId);   

            if(investment.Portfolio.OwnerId != requesterId)
            {
                throw new HandlerException("Você não possui autorização para resgatar esse investimento");
            }

            if(investment == null) 
            {
                throw new HandlerException("O investimento solicitado não existe");
            }

            if(investment.RedemptionDate.HasValue)
            {
                throw new HandlerException("O investimento solicitado já foi resgatado");
            }

            var evaluations = investmentEvaluationService.Evaluate(investment).Select(e => e.Value);
            investment.RedemptionDate = DateTimeOffset.Now;
            investment.Portfolio.Balance += evaluations.Any()? evaluations.Aggregate((acc, v) => acc + v) : 0; 

            return investment;
        }
    }
}