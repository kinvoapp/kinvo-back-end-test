using System;
using System.Threading.Tasks;
using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Contracts.Repositories {
    public interface IPortfolioRepository {
        void Add(Portfolio portfolio);

        Task<Portfolio> GetPortfolioByOwnerIdAsync(Guid ownerId);
    }
}