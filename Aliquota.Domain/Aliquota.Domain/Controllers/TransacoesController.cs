using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aliquota.Domain.Models;
using Microsoft.AspNetCore.Http;
namespace Aliquota.Domain.Controllers
{
    public class AplicacoesController : Controller
    {
        private readonly AliquotaContext _context;

        public AplicacoesController(AliquotaContext context)
        {
            _context = context;
        }

        // GET: Aplicacoes
        public async Task<IActionResult> AplicacaoIndex(int? clienteId)
        {
            if (HttpContext.Session.GetInt32("clienteId") != null)
                clienteId = HttpContext.Session.GetInt32("clienteId");
            else if (clienteId != null)
                HttpContext.Session.SetInt32("clienteId", Convert.ToInt32(clienteId));

            var aliquotaContext = _context.Aplicacoes.Include(t => t.Cliente).Include(t => t.Resgate);
            return View(await aliquotaContext.Where(t => t.ClienteId == clienteId).ToListAsync());
        }

        // GET: Aplicacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aplicacao = await _context.Aplicacoes
                .Include(t => t.Cliente)
                .FirstOrDefaultAsync(m => m.AplicacaoId == id);
            if (aplicacao == null)
            {
                return NotFound();
            }

            return View(aplicacao);
        }

        // GET: Aplicacoes/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nome", HttpContext.Session.GetInt32("clienteId"));
            return View();
        }

        // POST: Aplicacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AplicacaoId,Data,Valor,TaxaLucro,Periodicidade,Resgatado,ClienteId")] Aplicacao aplicacao)
        {
            if (ModelState.IsValid)
            {
                aplicacao.ClienteId = HttpContext.Session.GetInt32("clienteId");
                _context.Add(aplicacao);
                await _context.SaveChangesAsync();
                return RedirectToAction("AplicacaoIndex");
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nome", aplicacao.ClienteId);
            return View(aplicacao);
        }

        // GET: Aplicacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aplicacao = await _context.Aplicacoes.FindAsync(id);
            if (aplicacao == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nome", aplicacao.ClienteId);
            return View(aplicacao);
        }

        // POST: Aplicacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AplicacaoId,Tipo,Data,Valor,TaxaLucro,Periodicidade,Resgatado,ClienteId")] Aplicacao Aplicacao)
        {
            if (id != Aplicacao.AplicacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Aplicacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AplicacaoExists(Aplicacao.AplicacaoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("AplicacaoIndex");
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nome", Aplicacao.ClienteId);
            return View(Aplicacao);
        }

        // GET: Aplicacoes/Delete/5
        public async Task<IActionResult> Resgatar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Aplicacao = await _context.Aplicacoes
                .Include(t => t.Cliente)
                .FirstOrDefaultAsync(m => m.AplicacaoId == id);
            if (Aplicacao == null)
            {
                return NotFound();
            }
            Resgate resgate = new Resgate(Aplicacao);
            double ir = Aplicacao.calculaIR(resgate.Data);
            resgate.Valor = Aplicacao.Valor + Aplicacao.Rendimento - ir;
            resgate.ValorIr = ir;
            Aplicacao.Resgate = resgate;

            return View(Aplicacao);
        }

        // POST: Aplicacoes/Delete/5
        [HttpPost, ActionName("Resgatar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResgatarConfirmed(int? id, double valorResgate, double valorIr, [Bind("AplicacaoId,Tipo,Data,Valor,TaxaLucro,Periodicidade,Resgatado,ClienteId")] Aplicacao Aplicacao)
        {
            if (id != Aplicacao.AplicacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Resgate resgate = new Resgate(Aplicacao);
                    resgate.Valor = valorResgate;
                    resgate.ValorIr = valorIr;
                    _context.Add(resgate);
                    Aplicacao = _context.Aplicacoes.Include(t => t.Cliente).FirstOrDefault(t => t.AplicacaoId == id);             
                    Aplicacao.Resgatado = true;
                    _context.Update(Aplicacao);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    if (ex is DbUpdateConcurrencyException)
                    {
                        if (!AplicacaoExists(Aplicacao.AplicacaoId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    else if (ex is Exception)
                    {
                        ModelState.AddModelError(nameof(Aplicacao.Data), ex.Message);
                        return View(Aplicacao);
                    }
                }
                return RedirectToAction("AplicacaoIndex");
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nome", Aplicacao.ClienteId);
            return View(Aplicacao);
        }

        private bool AplicacaoExists(int id)
        {
            return _context.Aplicacoes.Any(e => e.AplicacaoId == id);
        }
    }
}
