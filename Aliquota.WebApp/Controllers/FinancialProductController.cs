using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aliquota.Domain.Contracts.Repositories;
using Aliquota.WebApp.Models;
using Aliquota.WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aliquota.WebApp.Controllers
{
    [ApiController]
    [Route("/api/products")]
    public class FinancialProductController
    {
        private readonly IFinancialProductRepository financialProductRepository;
        private readonly ModelConverter mc;

        public FinancialProductController(
            IFinancialProductRepository financialProductRepository,
            ModelConverter mc)
        {
            this.financialProductRepository = financialProductRepository;
            this.mc = mc;
        }

        public async Task<RequestResult<List<FinancialProductModel>>> GetFinancialProducts()
        {
            var products = await financialProductRepository.GetProductsAsync();
            return new RequestResult<List<FinancialProductModel>>
            {
                Success = true,
                Message = "Produtos obtidos com sucesso",
                Data = products.ConvertAll(p => mc.ToModel(p)),
            };
        }
    }
}