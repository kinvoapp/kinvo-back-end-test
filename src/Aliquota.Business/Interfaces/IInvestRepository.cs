using Aliquota.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Business.Interfaces
{
    public interface IInvestRepository
    {
        Task DeleteInvesAsync(int id);
        Task<Invest> GetInvestAsync(int id);
        Task<IEnumerable<Invest>> GetInvestsAsync();
        Task<Invest> InsertInvestAsync(Invest invest);
        Task<Invest> RescueInvestAsync(Invest invest);
        Task<Invest> UpdateInvestAsync(Invest invest);
    }
}
