using Aliquota.Application.Dtos;
using System.Collections.Generic;

namespace Aliquota.Application.Intefaces
{
    public interface IApplicationServiceFinancialApplication
    {
        void Add(FinancialApplicationDto applicationDto);
        void Update(FinancialApplicationDto applicationDto);
        void Remove(FinancialApplicationDto applicationDto);
        IEnumerable<FinancialApplicationDto> GetAll();
        FinancialApplicationDto GetById(int id);
    }
}
