using Aliquota.Domain.Business.IBusiness;
using Aliquota.Domain.Entities.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Aliquota.Web.Controllers
{
    public class TipoProdutosController : Controller
    {
        private readonly ITipoProdutoBusiness _tipoProdutoBusiness;
        public TipoProdutosController(ITipoProdutoBusiness tipoProdutoBusiness)
        {
            _tipoProdutoBusiness = tipoProdutoBusiness;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _tipoProdutoBusiness.GetListGrid());
        }

        // GET: TipoProdutosController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _tipoProdutoBusiness.GetItemById(id));
        }

        // GET: TipoProdutosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoProdutosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoProdutoDto item)
        {
            try
            {
                _tipoProdutoBusiness.Criar(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoProdutosController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _tipoProdutoBusiness.GetItemById(id));
        }

        // POST: TipoProdutosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TipoProdutoDto item)
        {
            try
            {
                _tipoProdutoBusiness.Editar(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoProdutosController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _tipoProdutoBusiness.GetItemById(id));
        }

        // POST: TipoProdutosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TipoProdutoDto item)
        {
            try
            {
                _tipoProdutoBusiness.DeleteById(item.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
