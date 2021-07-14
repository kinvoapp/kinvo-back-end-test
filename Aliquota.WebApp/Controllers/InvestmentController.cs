using System;
using System.Threading.Tasks;
using Aliquota.Domain.Commands;
using Aliquota.Domain.Contracts.Repositories;
using Aliquota.Domain.Handlers;
using Aliquota.Domain.Services;
using Aliquota.Persistence.Context;
using Aliquota.WebApp.Extensions;
using Aliquota.WebApp.Models;
using Aliquota.WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aliquota.WebApp.Controllers
{
    [ApiController]
    [Route("/api/investments")]
    public class InvestmentController : ControllerBase
    {
        private readonly IInvestmentRepository investmentRepository;
        private readonly InvestmentEvaluationService evaluationService;
        private readonly InvestmentHandler investmentHandler;
        private readonly AppDbContext context;
        private readonly ModelConverter mc;

        public InvestmentController(
            IInvestmentRepository investmentRepository,
            InvestmentEvaluationService evaluationService,
            ModelConverter mc,
            InvestmentHandler investmentHandler, 
            AppDbContext context)
        {
            this.investmentRepository = investmentRepository;
            this.evaluationService = evaluationService;
            this.mc = mc;
            this.investmentHandler = investmentHandler;
            this.context = context;
        }

        [Route("{id}")]
        public async Task<RequestResult<InvestmentFullModel>> GetInvestmentWithDetails([FromRoute] Guid id)
        {
            var investment = await investmentRepository.GetInvestmentAsync(id);

            if (investment == null)
            {
                return new RequestResult<InvestmentFullModel>
                {
                    Success = false,
                    Message = "O investimento não foi encontrado",
                };
            }

            if (investment.Portfolio.OwnerId != HttpContext.User.GetUserId())
            {
                return new RequestResult<InvestmentFullModel>
                {
                    Success = false,
                    Message = "Você não possui autorização para ver esse investimento",
                };
            }

            var evaluations = evaluationService.Evaluate(investment);

            return new RequestResult<InvestmentFullModel>
            {
                Success = true,
                Message = "Investimento obtido com sucesso!",
                Data = mc.ToFullModel(investment, evaluations),
            };
        }

        [HttpPost]
        public async Task<RequestResult<InvestmentModel>> CreateInvestment([FromBody] CreateInvestmentCommand command)
        {
            var userId = HttpContext.User.GetUserId();
            var investment = await investmentHandler.HandleAsync(command, userId);
            await context.SaveChangesAsync();

            return new RequestResult<InvestmentModel>
            {
                Success = true,
                Message = "Investimento aplicado com sucesso!",
                Data = mc.ToModel(investment),
            };
        }

        [HttpPost("redempt")]
        public async Task<RequestResult<InvestmentModel>> RedemptInvestment([FromBody] RedemptInvestmentCommand command)
        {
            var userId = HttpContext.User.GetUserId();
            var investment = await investmentHandler.HandleAsync(command, userId);
            await context.SaveChangesAsync();

            return new RequestResult<InvestmentModel>
            {
                Success = true,
                Message = "Investimento resgatado com sucesso!",
                Data = mc.ToModel(investment),
            };
        }
    }
}