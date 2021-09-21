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
            return CreatedAtAction(nameof(RecuperaInvestientoPorId), new { Id = investimento.Id }, investimento);
            
            //Console.WriteLine(investimento.Id);
             
            //Console.WriteLine("O nome do cliente é" + investimento.Cliente);
             
            //Console.WriteLine("O lucro foi de " + investimento.Lucro);

            //Console.WriteLine(investimento.TempoEmDias); 
            //Console.WriteLine(investimento.TempoEmAnos);

            //onsole.WriteLine(investimento.DataDeInicio); 
            //Console.WriteLine(investimento.DataDeResgate);
            if (investimento.TempoEmDias <= 365)
            {
                Console.WriteLine("O imposto foi de " + investimento.Lucro*0.225);
            }
            else if (investimento.TempoEmDias <= 365*2 && investimento.TempoEmDias > 365)
            {
                Console.WriteLine("O imposto foi de " + investimento.Lucro*0.185);
            }
            else if (investimento.TempoEmDias > 365*2)
            {
                Console.WriteLine("O imposto foi de " + investimento.Lucro*0.15);
            }
        }

        [HttpGet]
        public IActionResult RecuperaInvestimento()
        {
            return Ok(_context.Investimentos);

        }

        [HttpGet("{id}")]
        public IActionResult RecuperaInvestientoPorId (int id)
        {
            Investimento investimento = _context.Investimentos.FirstOrDefault(investimento => investimento.Id == id);
             if(investimento != null)
             {
                Ok(investimento);
             }
        }
    }
}
