using System;

using Aliquota.Domain.DTO;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Exceptions;
using Aliquota.Domain.Interfaces;
using Aliquota.Domain.Service.Interfaces;
using Aliquota.Domain.Utils;

namespace Aliquota.Domain.Service
{
    public class AliquotService : IAliquotService
    {
        private readonly IAliquotRepository _repository;

        public AliquotService(IAliquotRepository repository)
        {
            _repository = repository;
        }

        public ResponseApplicationDTO GetApplication(int id)
        {
            var application = _repository.GetApplication(id);

            if (application == null)
            {
                throw new BusinessException("Application not found"); 
            }

            return (ResponseApplicationDTO)application; 

        }
        public ResponseApplicationDTO Apply(ApplicationDTO application)
        {
            if (application.ApplicationValue <= 0)
            {
                throw new BusinessException("This application must bigger than 0");
            }

            return (ResponseApplicationDTO)_repository.Apply((Application)application);
        }
        public WithdrawDTO Withdraw(RequestWithdrawDTO withdraw)
        {
            var application = GetApplication(withdraw.ApplicationId);

            if (!application.IsActive)
            {
                throw new BusinessException("This application is already withdraw");
            }

            if (withdraw.WithdrawDate < application.ApplicationDate)
            {
                throw new BusinessException("Date withdraw must older than date application");
            }

            application.WithdrawDate = withdraw.WithdrawDate;
            application.IsActive = false;

            var timeElapsed = Convert.ToDecimal(withdraw.WithdrawDate.Subtract(application.ApplicationDate).TotalDays / Constants.DaysInOneYear);

            if (timeElapsed <= 1)
            {
                application.WithdrawValue = application.ApplicationValue - application.ApplicationValue * Constants.OneYearFactor;
            }
            else if (timeElapsed <= 2)
            {
                application.WithdrawValue = application.ApplicationValue - application.ApplicationValue * Constants.BetweenOneAndTwoYearsFactor;
            }
            else
            {
                application.WithdrawValue = application.ApplicationValue - application.ApplicationValue * Constants.PlusTwoYearsFactor;
            }

            return (WithdrawDTO)_repository.Withdraw((Application)application);
        }

    }
}