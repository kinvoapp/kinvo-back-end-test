using Aliquota.Application.Features.FinancialProducts.Commands;
using Aliquota.Application.Features.Investments.Commands;
using Aliquota.Application.Features.Investments.DTOs;
using Aliquota.Domain.Entities;
using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace Aliquota.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
            CreateMap<FinancialProduct, CreateFinancialProductCommand>().ReverseMap();
            CreateMap<Investment, CreateInvestmentCommand>().ReverseMap();
            CreateMap<Investment, WithdrawDTO>().ReverseMap();
            CreateMap<WithdrawDTO, Withdraw>().ReverseMap();
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i => 
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod("Mapping") 
                    ?? type.GetInterface("IMapFrom`1").GetMethod("Mapping");
                
                methodInfo?.Invoke(instance, new object[] { this });

            }
        }
    }
}