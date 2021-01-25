using Aliquota.Application.Interfaces;
using Aliquota.Application.ViewModels;
using Aliquota.Domain.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Application.Services
{
    public class ApplicationAppService : IApplicationAppService
    {
        private readonly IMapper _mapper;
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationAppService(IMapper mapper, IApplicationRepository applicationRepository)
        {
            _mapper = mapper;
            _applicationRepository = applicationRepository;
        }

        public async Task<List<ApplicationViewModel>> ListApplicationsAsync()
        {
            return _mapper.Map<List<ApplicationViewModel>>(await _applicationRepository.ListApplicationsAsync());
        }
    }
}
