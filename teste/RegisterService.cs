using AutoMapper;
using Kinvo.Aliquota.Domain.Entities.Clients;
using Kinvo.Aliquota.Domain.Entities.DateIncomeApplications;
using Kinvo.Aliquota.Domain.Entities.DateWithdrawals;
using Kinvo.Aliquota.Domain.Entities.IncomeApplications;
using Kinvo.Aliquota.Domain.Entities.Products;
using Kinvo.Aliquota.Models.Clients;
using Kinvo.Aliquota.Models.DateIncomeApplications;
using Kinvo.Aliquota.Models.DateWithdrawals;
using Kinvo.Aliquota.Models.IncomeApplications;
using Kinvo.Aliquota.Models.Products;

namespace Kinvo.Aliquota.Api.Console
{
    public class RegisterService : Profile
    {
        public RegisterService()
        {
            CreateMap<Client, ClientResponse>();
            CreateMap<Product, ProductResponse>();
            CreateMap<DateIncomeApplication, DateIncomeApplicationResponse>();
            CreateMap<DateWithdrawal, DateWithdrawalResponse>();
            CreateMap<IncomeApplication, IncomeApplicationResponse>();



            CreateMap<ClientRequest, Client>();
            CreateMap<ProductRequest, Product>();
            CreateMap<DateIncomeApplicationRequest, DateIncomeApplication>();
            CreateMap<DateWithdrawalRequest, DateWithdrawal>();
            CreateMap<IncomeApplicationRequest, IncomeApplication>();
        }
    }
}
