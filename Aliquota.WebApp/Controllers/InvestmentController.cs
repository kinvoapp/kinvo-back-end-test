using System;
using System.Threading.Tasks;
using Aliquota.Domain.Contracts.Repositories;
using Aliquota.Domain.Services;
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
        private readonly ModelConverter mc;

        public InvestmentController(IInvestmentRepository investmentRepository)
        {
            this.investmentRepository = investmentRepository;
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
                Message = "Investimento obtido com sucesso",
                Data = mc.ToFullModel(investment, evaluations),
            };
        }
    }
}