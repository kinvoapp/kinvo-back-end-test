using Aliquota.Application.Interfaces;
using Aliquota.Application.ViewModels;
using Aliquota.Domain.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Application.Services
{
    public class ContaAppService : IContaAppService
    {
        private readonly IMapper _mapper;
        private readonly IContaRepository _contaRepository;

        public ContaAppService(IMapper mapper, IContaRepository contaRepository)
        {
            _mapper = mapper;
            _contaRepository = contaRepository;
        }

        public async Task<IEnumerable<ContaViewModel>> ListContasAsync()
        {
            return _mapper.Map<List<ContaViewModel>>(await _contaRepository.ListContasAsync());
        }

        public async Task<ContaViewModel> GetContaByIdAsync(Guid id)
        {
            return _mapper.Map<ContaViewModel>(await _contaRepository.GetContaByIdAsync(id));
        }
    }
}
