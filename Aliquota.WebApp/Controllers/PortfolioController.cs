using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Aliquota.Domain.Contracts.Repositories;
using Aliquota.WebApp.Extensions;
using Aliquota.WebApp.Models;
using Aliquota.WebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aliquota.WebApp.Controllers {
    [ApiController]
    [Route("/api/portfolio")]
    public class PortfolioController : ControllerBase {
        private readonly IPortfolioRepository portfolioRepository;
        private readonly ModelConverter mc;

        public PortfolioController(IPortfolioRepository portfolioRepository, ModelConverter mc)
        {
            this.portfolioRepository = portfolioRepository;
            this.mc = mc;
        }

        [Authorize]
        public async Task<PortfolioModel> GetPortfolio() {
            var userId = HttpContext.User.GetUserId();
            var portfolio = await portfolioRepository.GetPortfolioByOwnerIdAsync(userId);
            return mc.ToModel(portfolio);
        }
    }
}