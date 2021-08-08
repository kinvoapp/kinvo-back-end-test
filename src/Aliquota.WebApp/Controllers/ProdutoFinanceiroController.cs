using Aliquota.Domain.Servicos.ProdutoFinanceiroSv;
using Aliquota.Domain.Servicos.TipoProdutoFinanceiroSv;
using Aliquota.WebApp.Extensoes;
using Aliquota.WebApp.Models.ProdutoFinanceiroViewModel;
using Aliquota.WebApp.Models.ResgateViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.WebApp.Controllers
{
    public class ProdutoFinanceiroController : Controller
    {
        private readonly IProdutoFinanceiroServico _produtoFinanceiroServico;
        private readonly ITipoProdutoFinanceiroServico _tipoProdutoFinanceiroServico;

        public ProdutoFinanceiroController(IProdutoFinanceiroServico produtoFinanceiroServico,
                                            ITipoProdutoFinanceiroServico tipoProdutoFinanceiroServico)
        {
            _produtoFinanceiroServico = produtoFinanceiroServico;
            _tipoProdutoFinanceiroServico = tipoProdutoFinanceiroServico;
        }

        public async Task<IActionResult> Visualizar(Guid? id)
        {
            if (!id.HasValue) return NotFound();
            var produtoFinanceiro = await _produtoFinanceiroServico.BuscaProdutoFinanceiroPor(id.Value);
            if (produtoFinanceiro == null) return NotFound();
            return View(new ProdutoFinanceiroVisulzVM(produtoFinanceiro));
        }

        public async Task<IActionResult> Novo()
        {
            var tiposProdutos = await _tipoProdutoFinanceiroServico.BuscarTodos();
            ViewData["TipoProdutoFinanceiroFK"] = new SelectList(tiposProdutos.ConverteParaViewModel()
                                                                    , "Id", "Nome", tiposProdutos.First());
            return View();
        }

        [HttpPost]
        public async Task<string> Resgatar([FromBody]ResgateVM resgateVM)
        {
            if (ModelState.IsValid)
            {
                var produtoFinanceiro = await _produtoFinanceiroServico.BuscaProdutoFinanceiroPor(resgateVM.Id);
                try
                {
                    await _produtoFinanceiroServico.ResgataProdutoFinanceiro(resgateVM.DataResgate,
                                                                                    produtoFinanceiro);
                    var meuJson = new { ValorIR = produtoFinanceiro.ValorIR, DataResgate = produtoFinanceiro.DataResgate.Value };
                    return JsonConvert.SerializeObject(meuJson);
                }
                catch (FormatException)
                {
                    var excecaoJson = new { Erro = "A data enviada está no formato incorreto" };
                    return JsonConvert.SerializeObject(excecaoJson);
                }
                catch (ArgumentException)
                {
                    var excecaoJson = new { Erro = "A Data de Resgate deve ser maior ou igual a data de aplicação." };
                    return JsonConvert.SerializeObject(excecaoJson);
                }
            }
            var erroJson = new { Erro = "A Data de Resgate ou o Id enviado está no formato incorreto" };
            return JsonConvert.SerializeObject(erroJson);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Novo(ProdutoFinanceiroFormVM form)
        {
            if (ModelState.IsValid)
            {
                await _produtoFinanceiroServico.CadastraProdutoFinanceiro(form.ConverteParaEntidade());
                return RedirectToAction("Index", "Painel");
            }
            var tiposProdutos = await _tipoProdutoFinanceiroServico.BuscarTodos();
            ViewData["TipoProdutoFinanceiroFK"] = new SelectList(tiposProdutos.ConverteParaViewModel(),
                                                                    "Id", "Nome", form.TipoProdutoFinanceiroFk);
            return View(form);
        }

        public async Task<IActionResult> Deletar(Guid? id)
        {
            if (!id.HasValue) return NotFound();
            var produtoFinanceiro = await _produtoFinanceiroServico.BuscaProdutoFinanceiroPor(id.Value);
            if (produtoFinanceiro == null) return NotFound();
            return View(new ProdutoFinanceiroVM(produtoFinanceiro));
        }

        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmacaoDeletar(Guid id)
        {
            var produtoFinanceiro = await _produtoFinanceiroServico.BuscaProdutoFinanceiroPor(id);
            if (produtoFinanceiro == null) return NotFound();
            await _produtoFinanceiroServico.DeletaProdutoFinanceiro(produtoFinanceiro);
            return RedirectToAction("Index","Painel");
        }


    }
}
