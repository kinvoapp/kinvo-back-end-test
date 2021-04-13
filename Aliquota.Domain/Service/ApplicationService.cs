using System;
using Aliquota.Data.Entity;
using Aliquota.Data.Interface;
using Aliquota.Domain.DTO;
using Aliquota.Domain.Service.Interface;
using Aliquota.Domain.Utils;

namespace Aliquota.Domain.Service
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository Repository;
        public ApplicationService(IApplicationRepository repository) 
        {
            Repository = repository;
        }

        public Application Apply(decimal applicationValue, long clientId)
        { 
            Application application = new Application()
            {
                ApplicationValue = applicationValue,
                ClientId = clientId
            };
            return Repository.Apply(application);
        }

        public ApplicationDTO Withdraw(ApplicationDTO application)
        {
            
            var period = Math.Round(Convert.ToDecimal(application.WithdrawDate?.Subtract(application.ApplicationDate).TotalDays / Constant.oneYear), 2);
           
            decimal withdralValue;

            if(period <= 1)
            {
                withdralValue = application.ApplicationValue - application.ApplicationValue * Constant.OneYearApp;
            }
            else if(period > 1 && period <= 2)
            {
                withdralValue = application.ApplicationValue - application.ApplicationValue * Constant.OneToTwoYearsApp;
            }
            else
            {
                withdralValue = application.ApplicationValue - application.ApplicationValue * Constant.MoreTwoYearsApp;
            }
            
            return (ApplicationDTO)Repository.Withdraw(application.Id, withdralValue);
        }

        public ApplicationDTO GetByCode(string applicationCode) => (ApplicationDTO)Repository.GetByCode(applicationCode);
    }
}