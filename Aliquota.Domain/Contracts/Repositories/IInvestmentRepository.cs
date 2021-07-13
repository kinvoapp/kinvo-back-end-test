using System;
using System.Threading.Tasks;
using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Contracts.Repositories {
    public interface IInvestmentRepository {
        Task<Investment> GetInvestmentAsync(Guid investmentId);
    }
}