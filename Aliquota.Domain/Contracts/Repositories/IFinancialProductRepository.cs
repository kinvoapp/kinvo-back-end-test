using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Contracts.Repositories {
    public interface IFinancialProductRepository {
        Task<List<FinancialProduct>> GetProductsAsync();
        Task<FinancialProduct> GetProductAsync(Guid productId);
    }
}