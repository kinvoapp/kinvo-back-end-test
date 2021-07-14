using System;
using System.Threading.Tasks;
using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Contracts.Repositories {
    public interface IInvestmentRepository {
        void Add(Investment investment);
        Task<Investment> GetInvestmentAsync(Guid investmentId);
    }
}