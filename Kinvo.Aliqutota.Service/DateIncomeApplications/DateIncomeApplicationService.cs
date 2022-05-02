using AutoMapper;
using Kinvo.Aliquota.Domain.Database.Interfaces.DateIncomeApplications;
using Kinvo.Aliquota.Domain.Entities.DateIncomeApplications;
using Kinvo.Aliquota.Models.DateIncomeApplications;
using Kinvo.Aliquota.Service.Interfaces.DateIncomeApplications;
using Kinvo.Aliquota.Validators.Interfaces.DateIncomeApplications;
using Kinvo.Aliqutota.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliqutota.Service.DateIncomeApplications
{
    public class DateIncomeApplicationService : BaseService<DateIncomeApplication>, IDateIncomeApplicationService
    {
        private readonly IDateIncomeApplicationRepository _dateIncomeApplicationRepository;
        private readonly IDateIncomeApplicationValidator _dateIncomeApplicationValidator;
        private readonly IMapper _mapper;

        public DateIncomeApplicationService(IDateIncomeApplicationRepository dateIncomeApplicationRepository, IDateIncomeApplicationValidator dateIncomeApplicationValidator, IMapper mapper)
            : base(dateIncomeApplicationRepository)
        {
            _dateIncomeApplicationRepository = dateIncomeApplicationRepository;
            _dateIncomeApplicationValidator = dateIncomeApplicationValidator;
            _mapper = mapper;
        }

        public async Task<DateIncomeApplicationResponse> Create(DateIncomeApplicationRequest dateIncomeApplicationRequest)
        {
            var client = _mapper.Map<DateIncomeApplication>(dateIncomeApplicationRequest);

            _dateIncomeApplicationRepository.Insert(client);
            return _mapper.Map<DateIncomeApplicationResponse>(client);

        }

        public async Task<DateIncomeApplicationResponse> Edit(Guid? Uuid, DateIncomeApplicationRequest dateIncomeApplicationRequest)
        {

            var dateIncomeApplication = await _dateIncomeApplicationRepository.FindAsync(Uuid.Value);

            dateIncomeApplication.ModificationDate = DateTime.Now;
            dateIncomeApplication.AppliedValue = dateIncomeApplicationRequest.AppliedValue;
            dateIncomeApplication.Active = dateIncomeApplicationRequest.Active;

            _dateIncomeApplicationRepository.Update(dateIncomeApplication);
            return _mapper.Map<DateIncomeApplicationResponse>(dateIncomeApplication);
        }

        public async Task Remove(Guid? Uuid)
        {
            var obj = await _dateIncomeApplicationRepository.FindAsync(Uuid.Value);

            _dateIncomeApplicationRepository.Delete(obj.Id);

            return;

        }

        public async Task<List<DateIncomeApplicationResponse>> List()
        {
            var obj = await _dateIncomeApplicationRepository.ListAsync();
            List<DateIncomeApplicationResponse> response = _mapper.Map<List<DateIncomeApplicationResponse>>(obj);

            return response;
           

        }
    }
}
