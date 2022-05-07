using Aliquota.Application.DTO;
using Aliquota.Application.Interfaces;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Interfaces.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Aliquota.Application.ApplicationService
{
    public class MovimentacaoServicoApp : IMovimentacaoServicoApp
    {
        private readonly IMovimentacaoServico _servico;
        private readonly Mapper _mapper;
    }
}