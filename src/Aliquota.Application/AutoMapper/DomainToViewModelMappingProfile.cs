using Aliquota.Application.ViewModels;
using Aliquota.Domain.Models;
using AutoMapper;

namespace Aliquota.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProdutoFinanceiro, ProdutoFinanceiroViewModel>();
        }
    }
}
