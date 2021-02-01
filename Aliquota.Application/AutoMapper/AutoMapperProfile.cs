using Aliquota.Application.ViewModels;
using Aliquota.Domain.Models;
using AutoMapper;

namespace Aliquota.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Aplicacao, AplicacaoViewModel>().ReverseMap();
            CreateMap<Domain.Models.Aplicacao, AplicacaoCreateViewModel>().ReverseMap();
            CreateMap<Aplicacao, AplicacaoEditViewModel>().ReverseMap();
        }
    }
}
