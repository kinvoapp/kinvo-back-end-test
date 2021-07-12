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

             _repository.Apply((Application)application);

            ResponseApplicationDTO returnApplicationDTO = new ResponseApplicationDTO()
            {
                ClientId = application.ClientId,
                ApplicationValue = application.ApplicationValue,
                ApplicationDate = application.ApplicationDate,
                IsActive = true
            };

            return returnApplicationDTO;
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

            var years = withdraw.WithdrawDate.Year - application.ApplicationDate.Year;

            if (years <= 1)
            {
                application.WithdrawValue = application.ApplicationValue - application.ApplicationValue * Constants.OneYearFactor;
            }
            else if (years <= 2)
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