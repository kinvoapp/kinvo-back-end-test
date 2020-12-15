using Aliquota.Application.Dtos;
using Aliquota.Application.Intefaces;
using Aliquota.Domain.Entitys;
using System.Collections.Generic;
using System.Linq;

namespace Aliquota.Application.Mapper
{
    public class MapperFinancialApplication : IMapperFinancialApplication
    {
        public FinancialApplication MapperDtoToEntity(FinancialApplicationDto financialApplicationDto)
        {
            var financialApplication = new FinancialApplication()
            {
                //Client = financialApplicationDto.Client,
                //Product = financialApplicationDto.Product,
                YieldRate = financialApplicationDto.YieldRate,
                DateApplication = financialApplicationDto.DateApplication,
                Investiment= financialApplicationDto.Investiment,
                DateRescue = financialApplicationDto.DateRescue
            };

            return financialApplication;
        }

        public FinancialApplicationDto MapperEntityToDto(FinancialApplication financialApplication)
        {
            var financialApplicatioDto = new FinancialApplicationDto()
            {
                // Client = financialApplication.Client,
                // Product = financialApplication.Product,
                YieldRate = financialApplication.YieldRate,
                DateApplication = financialApplication.DateApplication,
                Investiment = financialApplication.Investiment,
                DateRescue = financialApplication.DateRescue
            };
            return financialApplicatioDto;
        }

        public IEnumerable<FinancialApplicationDto> MapperListFinancialApplicationsDto(IEnumerable<FinancialApplication> financialApplications)
        {
            var dto = financialApplications.Select(f => new FinancialApplicationDto
            {
               // Client = f.Client,
               // Product = f.Product,
               YieldRate = f.YieldRate,
                DateApplication = f.DateApplication,
                Investiment = f.Investiment,
                DateRescue = f.DateRescue
            });
            return dto;
        }
    }
}
