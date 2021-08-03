using Aliquota.Application.Interfaces;
using Aliquota.Application.ViewModels;
using Aliquota.Domain.Interfaces;
using Aliquota.Domain.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Application.Services
{
    public class ProdutoFinanceiroService : IAdicionarProdutoFinanceiroService, IObterTodosProdutosFinanceirosService
    {
        private IMapper _mapper;
        private IProdutoFinanceiroRepository _produtoFinanceiroRepository;

        public ProdutoFinanceiroService(IMapper mapper, IProdutoFinanceiroRepository produtoFinanceiroRepository)
        {
            _mapper = mapper;
            _produtoFinanceiroRepository = produtoFinanceiroRepository;
        }

        public async Task<bool> Adicionar(CriarProdutoFinanceiroViewModel produtoFinanceiroViewModel)
        {
            var produtoFinanceiro = _mapper.Map<ProdutoFinanceiro>(produtoFinanceiroViewModel);

            await _produtoFinanceiroRepository.Adicionar(produtoFinanceiro);

            return await _produtoFinanceiroRepository.SaveChangesAsync();
        }

        public async Task<List<ProdutoFinanceiroViewModel>> ObterTodos()
        {
            var produtosFinanceirosList = await _produtoFinanceiroRepository.ObterTodos();

            if(produtosFinanceirosList?.Any() == true)
            {
                return _mapper.Map<List<ProdutoFinanceiroViewModel>>(produtosFinanceirosList);
            }

            return new List<ProdutoFinanceiroViewModel>();
        }
    }
}