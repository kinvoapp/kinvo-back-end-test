using Aliquota.Domain.Models;
using System.Collections.Generic;

namespace Aliquota.Domain.Repositories.Interfaces
{
    public interface IInvestmentRepository
    {
        public void Insert(Investment investment);
        public List<Investment> FindAll();
        public Investment GetById(int id);
        public void Update(Investment investment);
    }
}
