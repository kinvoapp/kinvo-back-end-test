using System.Threading.Tasks;
using Aliquota.Domain.Entities;

namespace Aliquota.Application.Interfaces.Repositories
{
    public interface IFinancialProductRepository : IGenericRepositoryAsync<FinancialProduct>
    {
        Task<bool> IsNameUnique(string name);
    }
}
