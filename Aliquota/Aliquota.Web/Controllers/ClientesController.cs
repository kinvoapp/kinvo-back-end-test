using Aliquota.Domain.Business.IBusiness;
using Aliquota.Domain.Entities.DTO;
using Aliquota.Domin.Util.Enum;
using Aliquota.Domin.Util.Excecoes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Web.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteBusiness _clienteBusiness;
        private readonly ISituacaoProdutoBusiness _situacaoProdutoBusiness;
        private readonly ITipoProdutoBusiness _tipoProdutoBusiness;
        private readonly IProdutoBusiness _produtoBusiness;

        public ClientesController(IClienteBusiness clienteBusiness, ISituacaoProdutoBusiness situacaoProdutoBusiness, ITipoProdutoBusiness tipoProdutoBusiness, IProdutoBusiness produtoBusiness)
        {
            _clienteBusiness = clienteBusiness;
            _situacaoProdutoBusiness = situacaoProdutoBusiness;
            _tipoProdutoBusiness = tipoProdutoBusiness;
            _produtoBusiness = produtoBusiness;
        }

        // GET: ClientesController
        public async Task<ActionResult> Index()
        {
            return View(await _clienteBusiness.GetListGrid());
        }

        // GET: ClientesController/Details/5
        public async Task<ActionResult> Details(int Id)
        {
            return View(await _clienteBusiness.GetItemById(Id));
        }

        
        public async Task<ActionResult> CadastrarProduto(int id)
        {
            var model = new ProdutoDto();
            model.IdCliente = id;
            model.IdSituacaoProduto = (int)SituacaoProdutoEnum.NaoMovimentado;
            ViewBag.Proprietario = await _clienteBusiness.GetItemById(id);
            ViewBag.SituacaoAtual = await _situacaoProdutoBusiness.GetItemById((int)SituacaoProdutoEnum.NaoMovimentado);
            ViewBag.ListaTipoProduto = new SelectList(await _tipoProdutoBusiness.GetListGrid(), "Id", "NomeRentabilidade");
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CadastrarProduto(ProdutoDto item)
        {
            try
            {
                await _clienteBusiness.CadastrarProduto(item);
                return RedirectToAction(nameof(Details),new { Id = item.IdCliente });
            }
            catch(Exception e)
            {
                return View();
            }
        }
        public async Task<ActionResult> MovimentarProduto(int id)
        {
            var model = await _produtoBusiness.GetItemById(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MovimentarProduto(ProdutoDto item)
        {
            try
            {
                await _clienteBusiness.MovimentarProduto(item);
                return RedirectToAction(nameof(Details), new { Id = item.IdCliente });
            }
            catch (BusinessException e)
            {
                ModelState.AddModelError("DataResgate",e.Message);
                return View(await _produtoBusiness.GetItemById(item.Id));
            }
        }

        public async Task<ActionResult> DeleteProduto(int id)
        {
            var model = await _produtoBusiness.GetItemById(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteProduto(ProdutoDto item)
        {
            try
            {
                await _produtoBusiness.DeleteById(item.Id);
                return RedirectToAction(nameof(Details), new { Id = item.IdCliente });
            }
            catch (Exception e)
            {
                return View();
            }
        }
        // GET: ClientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ClienteDto item)
        {
            try
            {
                await _clienteBusiness.Criar(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _clienteBusiness.GetItemById(id));
        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ClienteDto item)
        {
            try
            {
                await _clienteBusiness.Editar(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesController/Delete/5
        public  async Task<ActionResult> Delete(int id)
        {
            return View(await _clienteBusiness.GetItemById(id));
        }

        // POST: ClientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, ClienteDto item)
        {
            try
            {
                await _clienteBusiness.DeleteById(item.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
