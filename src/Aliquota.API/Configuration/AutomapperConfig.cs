using AutoMapper;
using Aliquota.API.ViewModels;
using Aliquota.Domain.Models;

namespace Aliquota.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<Posicao, PosicaoViewModel>().ReverseMap();
        }
    }
}
