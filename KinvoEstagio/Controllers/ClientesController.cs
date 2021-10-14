using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KinvoEstagio.Data;
using KinvoEstagio.Models;

namespace KinvoEstagio.Controllers
{
    public class ClientesController : Controller
    {
        private readonly KinvoEstagioContext _context;

        public ClientesController(KinvoEstagioContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cliente.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }


        public double Iof(DateTime comeco, DateTime fim)
        {
            DateTime Tempo = comeco;
            var diferenca = (DateTime.Now - comeco).Days;
            if (diferenca <= 30)
            {
                double iof = 99;
                for (int i =0; i < diferenca; i++)
                {
                    if (iof %10 == 0)
                    {
                        iof = iof - 4;
                    }
                    else
                    {
                        iof = iof - 3;
                    }
                }
                return iof;
            }
            else
            {
                return 0;
            }

        }

        public double Ir(DateTime Tempo)
        {
            double IR;
            DateTime Data = Tempo;
            var diferenca = (DateTime.Now - Tempo).Days;
            if(diferenca <= 361)
            {
                IR = 22.5;
            }
            else if(diferenca > 362 && diferenca <= 720)
            {
                IR = 18.5;
            }
            else
            {
                IR = 15;
            }
            return IR;
        }

        public double valorIr(double lucro, double iof, double ir)
        {
            if(iof == 0)
            {
                var valorir = lucro * (ir / 100);
                valorir = Math.Round(valorir, 2);
                return valorir;
            }
            else
            {
                var valoriof = lucro * (iof / 100);
                var valorir = valoriof + (valoriof * (ir / 100));
                valorir = Math.Round(valorir, 2);
                return valorir;
            }
        }
        public double Renda(double rendimento, double lucro, double valorir)
        {
            var resgate = rendimento + (lucro - valorir);
            return resgate;
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Nome,Investimento,Tempo,Imposto,Rendimento")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Nome,Investimento,Tempo,Imposto,Rendimento")] Cliente cliente)
        {
            if (id != cliente.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.id == id);
        }
    }
}
