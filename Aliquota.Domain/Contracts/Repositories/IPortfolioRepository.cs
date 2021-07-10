using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Contracts.Repositories {
    public interface IPortfolioRepository {
        void Add(Portfolio portfolio);
    }
}