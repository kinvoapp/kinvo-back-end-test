using Aliquota.Application.Interfaces;
using Aliquota.Application.ViewModels;
using Aliquota.Domain.Interfaces;
using Aliquota.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Application.Services
{
    public class AplicacaoService : BaseService, IAplicacaoService
    {
        private readonly IMapper _mapper;
        private readonly IAplicacaoRepository _aplicacaoRepository;

        public AplicacaoService(IMapper mapper, IAplicacaoRepository applicationRepository)
        {
            _mapper = mapper;
            _aplicacaoRepository = applicationRepository;
        }

        public async Task<List<AplicacaoViewModel>> ObterTodos()
        {
            return _mapper.Map<List<AplicacaoViewModel>>(await _aplicacaoRepository.ObterTodos());
        }

        public async Task<AplicacaoViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<AplicacaoViewModel>(await _aplicacaoRepository.ObterPorId(id));
        }

        public void Dispose()
        {
            _aplicacaoRepository?.Dispose();
        }

        public async Task<bool> Adicionar(AplicacaoCreateViewModel oView)
        {
            var o = _mapper.Map<Aplicacao>(oView);
            o.ValorAtual = o.ValorAplicado;

            await _aplicacaoRepository.Adicionar(o);
            
            return true;
        }

        public async Task<bool> Atualizar(AplicacaoEditViewModel oView)
        {
            var o = _mapper.Map<Aplicacao>(oView);

            var objBd = await _aplicacaoRepository.ObterPorId(oView.Id);
            objBd.ValorAtual = o.ValorAtual;
            objBd.DataRetirada = o.DataRetirada;

            await _aplicacaoRepository.Atualizar(objBd);

            return true;
        }

        public async Task<bool> Excluir(Guid id)
        {
            await _aplicacaoRepository.Remover(id);

            return true;
        }

    }
}
