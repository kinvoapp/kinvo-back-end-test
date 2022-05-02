using AutoMapper;
using Kinvo.Aliquota.Domain.Database.Interfaces.IncomeApplications;
using Kinvo.Aliquota.Domain.Entities.IncomeApplications;
using Kinvo.Aliquota.Models.IncomeApplications;
using Kinvo.Aliquota.Service.Interfaces.IncomeApplications;
using Kinvo.Aliquota.Validators.Interfaces.IncomeApplications;
using Kinvo.Aliqutota.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliqutota.Service.IncomeApplications
{
    public class IncomeApplicationService : BaseService<IncomeApplication>, IIncomeApplicationService
    {
        private readonly IIncomeApplicationRepository _incomeApplicationRepository;
        private readonly IIncomeApplicationValidator _incomeApplicationValidator;
        private readonly IMapper _mapper;

        public IncomeApplicationService(IIncomeApplicationRepository incomeApplicationRepository, IIncomeApplicationValidator incomeApplicationValidator, IMapper mapper)
            : base(incomeApplicationRepository)
        {
            _incomeApplicationRepository = incomeApplicationRepository;
            _incomeApplicationValidator = incomeApplicationValidator;
            _mapper = mapper;
        }

        public async Task<IncomeApplicationResponse> Create(IncomeApplicationRequest incomeApplicationRequest)
        {
            var incomeApplication = _mapper.Map<IncomeApplication>(incomeApplicationRequest);

            _incomeApplicationRepository.Insert(incomeApplication);
            return _mapper.Map<IncomeApplicationResponse>(incomeApplication);

        }

        public async Task<IncomeApplicationResponse> Edit(Guid? Uuid, IncomeApplicationRequest incomeApplicationRequest)
        {

            var incomeApplication = await _incomeApplicationRepository.FindAsync(Uuid.Value);

            incomeApplication.ModificationDate = DateTime.Now;
            incomeApplication.AppliedValue = incomeApplicationRequest.AppliedValue;
            incomeApplication.ClientId = incomeApplicationRequest.ClientId;
            incomeApplication.ProductId = incomeApplicationRequest.ProductId;
            

            _incomeApplicationRepository.Update(incomeApplication);
            return _mapper.Map<IncomeApplicationResponse>(incomeApplication);
        }

        public async Task Remove(Guid? Uuid)
        {
            var obj = await _incomeApplicationRepository.FindAsync(Uuid.Value);

            _incomeApplicationRepository.Delete(obj.Id);

            return;

        }

        public async Task<List<IncomeApplicationResponse>> List()
        {
            var obj = await _incomeApplicationRepository.ListAsync();
            List<IncomeApplicationResponse> response = _mapper.Map<List<IncomeApplicationResponse>>(obj);

            return response;


        }
    }
}
