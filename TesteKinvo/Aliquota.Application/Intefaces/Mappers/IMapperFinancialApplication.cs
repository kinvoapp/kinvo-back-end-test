using Aliquota.Application.Dtos;
using Aliquota.Domain.Entitys;
using System.Collections.Generic;

namespace Aliquota.Application.Intefaces
{
    public interface IMapperFinancialApplication
    {
        FinancialApplication MapperDtoToEntity(FinancialApplicationDto financialApplicationDto);
        IEnumerable<FinancialApplicationDto> MapperListFinancialApplicationsDto(IEnumerable<FinancialApplication> financialApplications);
        FinancialApplicationDto MapperEntityToDto(FinancialApplication financialApplication);
    }
}
