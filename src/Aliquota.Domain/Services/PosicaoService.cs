using Aliquota.Domain.Models;
using Aliquota.Domain.Interfaces;
using Aliquota.Domain.Models.Validations;

namespace Aliquota.Domain.Services
{
    public class PosicaoService : BaseService, IPosicaoService
    {
        private readonly IPosicaoRepository _posicaoRepository;
        private readonly IProdutoRepository _produtoRepository;

        public PosicaoService(IPosicaoRepository posicaoRepository,
                              IProdutoRepository produtoRepository,
                              INotificador notificador) : base(notificador)
        {
            _posicaoRepository = posicaoRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task Adicionar(Posicao posicao)
        {
            if (!ExecutarValidacao(new PosicaoValidation(), posicao)) return;


            if (!ValidarDeposito(posicao))
            {
                Notificar("Depósito deve ser maior que zero");
                return;
            }


            await _posicaoRepository.Adicionar(posicao);
        }

        public async Task Atualizar(Posicao posicao)
        {
            if (!ExecutarValidacao(new PosicaoValidation(), posicao)) return;


            if (!ValidarResgate(posicao))
            {
                Notificar("Data resgate deve ser maior que data depósito");
                return;
            }

            //posicao.ValorResgatado = 

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

        public bool ValidarDeposito(Posicao posicao)
        {
            if (posicao == null)
                return false;

            if (posicao.ValorAportado <= 0)
                return false;

            return true;
        }

        public bool ValidarResgate(Posicao posicao)
        {
            if (posicao.DataAporte > posicao.DataResgate)
                return false;

            return true;
        }

        public decimal CalculaRentabilidade(Posicao posicao)
        {
            //Produto produto = _produtoRepository.ObterPorId(posicao.ProdutoId);

            DateTime dataResgate = (DateTime)posicao.DataResgate;
            int dias = (dataResgate - posicao.DataAporte).Days;

            double faixaImposto;

            if (dias < 365)
                faixaImposto = 22.5;
            else if (dias >= 365 || dias < 730)
                faixaImposto = 18.5;
            else
                faixaImposto = 15;

            return 0;
        }

    }
}
