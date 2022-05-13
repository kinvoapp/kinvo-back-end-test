using AutoMapper;
using Kinvo.Aliquota.Domain.Database.Interfaces.DateWithdrawals;
using Kinvo.Aliquota.Domain.Entities.DateWithdrawals;
using Kinvo.Aliquota.Models.DateWithdrawals;
using Kinvo.Aliquota.Service.Interfaces.DateWithdrawals;
using Kinvo.Aliquota.Validators.Interfaces.DateWithdrawals;
using Kinvo.Aliqutota.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliqutota.Service.DateWithdrawals
{
    public class DateWithdrawalService : BaseService<DateWithdrawal>, IDateWithdrawalService
    {
        private readonly IDateWithdrawalRepository _dateWithdrawalRepository;
        private readonly IDateWithdrawalValidator _dateWithdrawalValidator;
        private readonly IMapper _mapper;

        public DateWithdrawalService(IDateWithdrawalRepository dateWithdrawalRepository, IDateWithdrawalValidator dateWithdrawalValidator, IMapper mapper)
            : base(dateWithdrawalRepository)
        {
            _dateWithdrawalRepository = dateWithdrawalRepository;
            _dateWithdrawalValidator = dateWithdrawalValidator;
            _mapper = mapper;
        }

        public async Task<DateWithdrawalResponse> Create(DateWithdrawalRequest dateWithdrawalRequest)
        {
            var dateWithdrawal = _mapper.Map<DateWithdrawal>(dateWithdrawalRequest);

            _dateWithdrawalRepository.Insert(dateWithdrawal);
            return _mapper.Map<DateWithdrawalResponse>(dateWithdrawal);

        }

        public async Task<DateWithdrawalResponse> Edit(Guid? Uuid, DateWithdrawalRequest dateWithdrawalRequest)
        {

            var dateWithdrawal = await _dateWithdrawalRepository.FindAsync(Uuid.Value);

            dateWithdrawal.ModificationDate = DateTime.Now;
            dateWithdrawal.WithdrawalValue = dateWithdrawalRequest.WithdrawalValue;
            dateWithdrawal.Active = dateWithdrawalRequest.Active;

            _dateWithdrawalRepository.Update(dateWithdrawal);
            return _mapper.Map<DateWithdrawalResponse>(dateWithdrawal);
        }

        public async Task Remove(Guid? Uuid)
        {
            var obj = await _dateWithdrawalRepository.FindAsync(Uuid.Value);

            _dateWithdrawalRepository.Delete(obj.Id);

            return;

        }

        public async Task<List<DateWithdrawalResponse>> List()
        {
            var obj = await _dateWithdrawalRepository.ListAsync();
            List<DateWithdrawalResponse> response = _mapper.Map<List<DateWithdrawalResponse>>(obj);

            return response;


        }
    }
}
