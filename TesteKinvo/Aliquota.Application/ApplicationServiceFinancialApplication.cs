using Aliquota.Application.Dtos;
using Aliquota.Application.Intefaces;
using Aliquota.Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Application
{
    public class ApplicationServiceFinancialApplication : IApplicationServiceFinancialApplication
    {
        private readonly IServiceFinancialApplication serviceFinancialApplication;
        private readonly IMapperFinancialApplication mapperFinancialApplication;

        public ApplicationServiceFinancialApplication(IServiceFinancialApplication serviceFinancialApplication,
                                                      IMapperFinancialApplication mapperFinancialApplication)
        {
            this.serviceFinancialApplication = serviceFinancialApplication;
            this.mapperFinancialApplication = mapperFinancialApplication;
        }

        public void Add(FinancialApplicationDto applicationDto)
        {
            var financialApplication = mapperFinancialApplication.MapperDtoToEntity(applicationDto);
            serviceFinancialApplication.Add(financialApplication);
        }

        public IEnumerable<FinancialApplicationDto> GetAll()
        {
            var financialApplications = serviceFinancialApplication.GetAll();
            return mapperFinancialApplication.MapperListFinancialApplicationsDto(financialApplications);
        }

        public FinancialApplicationDto GetById(int id)
        {
            var financialApplication = serviceFinancialApplication.GetById(id);
            return mapperFinancialApplication.MapperEntityToDto(financialApplication);
        }

        public void Remove(FinancialApplicationDto applicationDto)
        {
            var financialApplication = mapperFinancialApplication.MapperDtoToEntity(applicationDto);
            serviceFinancialApplication.Remove(financialApplication);
        }

        public void Update(FinancialApplicationDto applicationDto)
        {
            var financialApplication = mapperFinancialApplication.MapperDtoToEntity(applicationDto);
            serviceFinancialApplication.Update(financialApplication);
        }
    }
}
