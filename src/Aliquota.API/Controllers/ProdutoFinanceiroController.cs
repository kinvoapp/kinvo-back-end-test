using Aliquota.Application.Interfaces;
using Aliquota.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.API.Controllers
{
    [Route("produto-financeiro")]
    public class ProdutoFinanceiroController : Controller
    {
        private IAdicionarProdutoFinanceiroService _adicionarProdutoFinanceiroService;
        private IObterTodosProdutosFinanceirosService _obterTodosProdutosFinanceirosService;
        private IImpostoDeRendaService _impostoDeRendaService;

        public ProdutoFinanceiroController(IAdicionarProdutoFinanceiroService adicionarProdutoFinanceiroService, IImpostoDeRendaService impostoDeRendaService, IObterTodosProdutosFinanceirosService obterTodosProdutosFinanceirosService)
        {
            _adicionarProdutoFinanceiroService = adicionarProdutoFinanceiroService;
            _impostoDeRendaService = impostoDeRendaService;
            _obterTodosProdutosFinanceirosService = obterTodosProdutosFinanceirosService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var produtosFinanceiros = await _obterTodosProdutosFinanceirosService.ObterTodos();
            return CustomResponse(produtosFinanceiros);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(CriarProdutoFinanceiroViewModel produtoFinanceiroViewModel)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse();
            }

            var adicionado = await _adicionarProdutoFinanceiroService.Adicionar(produtoFinanceiroViewModel);

            if(!adicionado)
            {
                return CustomResponse("Algo inesperado aconteceu e o Produto Financeiro não foi adicionado", true);
            }

            return CustomResponse("Produto financeiro adicionado com sucesso!");
        }

        [HttpGet("{produtoFinanceiroId:Guid}")]
        public async Task<IActionResult> Calcular(Guid produtoFinanceiroId)
        {
            var impostoDeRenda = await _impostoDeRendaService.Calcular(produtoFinanceiroId);
            return CustomResponse(impostoDeRenda);
        }
    }
}
