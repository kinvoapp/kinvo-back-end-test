using System;

using Aliquota.Domain.DTO;
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
                throw new BusinessException("Aplica��o n�o encontrada"); 
            }

            return (ResponseApplicationDTO)application; 

        }
        public ResponseApplicationDTO Apply(ApplicationDTO application)
        {
            if (application.Value <= 0)
            {
                throw new BusinessException("A aplica��o n�o pode ser igual ou menor que zero");
            }

            var newApplication = _repository.Apply(application);

            ResponseApplicationDTO returnApplicationDTO = new ResponseApplicationDTO()
            {
                ClientId = newApplication.ClientId,
                ApplicationValue = newApplication.ApplicationValue,
                ApplicationDate = newApplication.ApplicationDate,
                IsActive = true
            };

            return returnApplicationDTO;
        }
        public WithdrawDTO Withdraw(RequestWithdrawDTO withdraw)
        {
            var application = _repository.GetApplication(withdraw.ApplicationId);

            if (!application.IsActive)
            {
                throw new BusinessException("Esta aplica��o j� foi resgatada");
            }

            if (withdraw.WithdrawDate < application.ApplicationDate)
            {
                throw new BusinessException("A data de resgate n�o pode ser menor que a data de aplica��o");
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

            return (WithdrawDTO)_repository.Withdraw(application);
        }

    }
}