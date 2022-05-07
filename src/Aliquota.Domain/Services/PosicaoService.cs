using Aliquota.Domain.Interfaces;
using Aliquota.Domain.Models;
using Aliquota.Domain.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Services
{
    public class PosicaoService : BaseService, IPosicaoService
    {
        private readonly IPosicaoRepository _posicaoRepository;

        public PosicaoService(IPosicaoRepository posicaoRepository,
                              INotificador notificador) : base(notificador)
        {
            _posicaoRepository = posicaoRepository;
        }

        public async Task Adicionar(Posicao posicao)
        {
            if (!ExecutarValidacao(new PosicaoValidation(), posicao)) return;

            await _posicaoRepository.Adicionar(posicao);
        }

        public async Task Atualizar(Posicao posicao)
        {
            if (!ExecutarValidacao(new PosicaoValidation(), posicao)) return;

            await _posicaoRepository.Atualizar(posicao);
        }

        public async Task Remover(Guid id)
        {
            await _posicaoRepository.Remover(id);
        }

        public void Dispose()
        {
            _posicaoRepository?.Dispose();
        }
    }
}
