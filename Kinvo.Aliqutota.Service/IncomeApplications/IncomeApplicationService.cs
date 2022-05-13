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
using Kinvo.Aliquota.Validators.Interfaces.Clients;
using Kinvo.Aliquota.Validators.Interfaces.Products;

namespace Kinvo.Aliqutota.Service.IncomeApplications
{
    public class IncomeApplicationService : BaseService<IncomeApplication>, IIncomeApplicationService
    {
        private readonly IIncomeApplicationRepository _incomeApplicationRepository;
        private readonly IIncomeApplicationValidator _incomeApplicationValidator;
        private readonly IProductValidator _productValidator;
        private readonly IClientValidator _clientValidator;
        private readonly IMapper _mapper;

        public IncomeApplicationService(IIncomeApplicationRepository incomeApplicationRepository, 
                                        IIncomeApplicationValidator incomeApplicationValidator, 
                                        IMapper mapper,
                                        IProductValidator productValidator,
                                        IClientValidator clientValidator)
                                                        : base(incomeApplicationRepository)
        {
            _incomeApplicationRepository = incomeApplicationRepository;
            _incomeApplicationValidator = incomeApplicationValidator;
            _mapper = mapper;
            _productValidator = productValidator;
            _clientValidator = clientValidator;
        }

        public async Task<IncomeApplicationResponse> Create(IncomeApplicationRequest incomeApplicationRequest)
        {
            await _productValidator.ValidateUuid(incomeApplicationRequest.Product.Uuid);

            await _clientValidator.ValidateUuid(incomeApplicationRequest.Client.Uuid);
            
            await _incomeApplicationValidator.ValidateCreation(incomeApplicationRequest);

            var incomeApplication = _mapper.Map<IncomeApplication>(incomeApplicationRequest);
            var dateIncomeApplications = incomeApplication.DateIncomeApplication;
            
            dateIncomeApplications.ToList().ForEach(application =>
            {
                application.Uuid = Guid.NewGuid();
                application.AppliedValue = incomeApplication.AppliedValue;
            });

            _incomeApplicationRepository.Insert(incomeApplication);
            return _mapper.Map<IncomeApplicationResponse>(incomeApplication);

        }

        public async Task<IncomeApplicationResponse> Edit(Guid? Uuid, IncomeApplicationRequest incomeApplicationRequest)
        {

            var incomeApplication = await _incomeApplicationRepository.FindAsync(Uuid.Value);

            incomeApplication.ModificationDate = DateTime.Now;
            incomeApplication.AppliedValue = incomeApplicationRequest.AppliedValue;
            incomeApplication.Client = incomeApplicationRequest.Client;
            incomeApplication.Product = incomeApplicationRequest.Product;
            

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
