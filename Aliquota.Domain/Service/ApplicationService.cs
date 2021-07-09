using System;
using System.Collections.Generic;

using Aliquota.Domain.DTO;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Interfaces;

namespace Aliquota.Domain.Service
{
    public class ApplicationService
    {
        private readonly IApplicationRepository _repository;

        public ApplicationService(IApplicationRepository repository)
        {
            _repository = repository;
        }

        public WithdrawDTO GetApplication(int id)
        {
            var application = _repository.GetApplication(id);

            if (application != null)
            {
                return (WithdrawDTO)application;
            }

            return null;

        }
        public ReturnApplicationDTO Apply(ApplicationDTO model, Client client)
        {
            var application = new Application()
            {
                ApplicationValue = model.Value,
                ApplicationDate = model.ApplicationDate,
                Client = client,
                ClientId = client.Id,
                IsActive = true
            };

            _repository.Apply(application);

            ReturnApplicationDTO returnApplicationDTO = new ReturnApplicationDTO()
            {
                ClientId = application.ClientId,
                Value = application.ApplicationValue,
                ApplicationDate = application.ApplicationDate
            };

            return returnApplicationDTO;
        }
        public Application Withdraw(int id)
        {
            var application = _repository.GetApplication(id);

            application.WithdrawDate = DateTime.Now;
            application.IsActive = false;

            return application;
        }
    }
}