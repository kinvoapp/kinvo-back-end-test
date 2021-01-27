using Aliquota.Application.ViewModels;
using Aliquota.Infra.Data;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Models.Conta, ContaViewModel>().ReverseMap();
        }
    }
}
