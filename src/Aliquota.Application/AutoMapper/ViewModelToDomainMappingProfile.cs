using Aliquota.Application.ViewModels;
using Aliquota.Domain.Models;
using AutoMapper;

namespace Aliquota.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProdutoFinanceiroViewModel, ProdutoFinanceiro>()
                .ConstructUsing(p => new ProdutoFinanceiro(p.Aplicacao, p.DataAplicacao, p.Lucro, p.DataResgate));

            CreateMap<CriarProdutoFinanceiroViewModel, ProdutoFinanceiro>()
                .ConstructUsing(p => new ProdutoFinanceiro(p.Aplicacao, p.DataAplicacao, p.Lucro, p.DataResgate));
        }
    }
}