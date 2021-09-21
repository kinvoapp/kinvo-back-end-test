using Aliquota.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.Domain.Data;

namespace Aliquota.Domain.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class KinvoController : ControllerBase
    {  
        private InvestimentoContext _context;

        public KinvoController(InvestimentoContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionarInvestimento([FromBody] Investimento investimento)
        {
            _context.Investimentos.Add(investimento);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaInvestientoPorId), new { Id = investimento.Id }, investimento);
        }

        [HttpGet]
        public IEnumerable <Investimento>RecuperaInvestimento()
        {
            return _context.Investimentos;

        }

        [HttpGet("{id}")]
        public IActionResult RecuperaInvestientoPorId (int id)
        {
            Investimento investimento = _context.Investimentos.FirstOrDefault(investimento => investimento.Id == id);
             if(investimento != null)
             {
                Ok(investimento);
             }
             return NotFound();
        }
    }
}
