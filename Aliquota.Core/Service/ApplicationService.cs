using System;
using Aliquota.Core.DTO;
using Aliquota.Core.Interface;
using Aliquota.Domain.Entity;
using Aliquota.Domain.Interface;

namespace Aliquota.Core.Service
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository repository;

        public ApplicationService(IApplicationRepository repository)
        {
            this.repository = repository;
        }

        public void Create(decimal value, string fantasyName)
        {
            Share share = new Share()
            {
                Value = value,
                FantasyName = fantasyName,
                ApplicationDate = DateTime.Now
            };

            repository.Create(share);
        }

        public WithDrawApplicationDto WithDrawShareApplication(string fantasyName) => (WithDrawApplicationDto)repository.WithDrawShareApplication(fantasyName);
    }
}
