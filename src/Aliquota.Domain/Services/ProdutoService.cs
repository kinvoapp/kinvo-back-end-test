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
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPosicaoRepository _posicaoRepository;

        public ProdutoService(IProdutoRepository produtoRepository,
                              IPosicaoRepository posicaoRepository,
                              INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _posicaoRepository = posicaoRepository;
        }

        public async Task Adicionar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            if (_produtoRepository.Buscar(p => p.Nome == produto.Nome).Result.Any())
            {
                Notificar("Já existe um produto com este nome infomado.");
                return;
            }

            await _produtoRepository.Adicionar(produto);
        }

        public async Task Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            if (_produtoRepository.Buscar(p => p.Nome == produto.Nome && p.Id != produto.Id).Result.Any())
            {
                Notificar("Já existe um produto com este documento infomado.");
                return;
            }

            await _produtoRepository.Atualizar(produto);
        }        

        public async Task Remover(Guid id)
        {
            /* Todo
            if (_produtoRepository.ObterPosicoesAtivasProduto(id).Result.Posicoes.Any())
            {
                Notificar("O produto ainda possui posições ativas!");
                return;
            }*/

            await _produtoRepository.Remover(id);
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
            _posicaoRepository?.Dispose();
        }
    }
}
