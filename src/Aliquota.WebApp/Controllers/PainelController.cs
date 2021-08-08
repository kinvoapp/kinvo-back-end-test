using Aliquota.Domain.Servicos.ProdutoFinanceiroSv;
using Aliquota.WebApp.Extensoes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Aliquota.WebApp.Controllers
{
    public class PainelController : Controller
    {

        private IProdutoFinanceiroServico _produtoFinanceiroServico;

        public PainelController(IProdutoFinanceiroServico produtoFinanceiroServico)
        {
            _produtoFinanceiroServico = produtoFinanceiroServico;
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoFinanceiroServico.BuscarTodos();
            return View(produtos.ConverteParaViewModel());
        }

    }
}
