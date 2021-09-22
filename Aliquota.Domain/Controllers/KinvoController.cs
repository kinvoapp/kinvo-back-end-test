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
        public IEnumerable <Investimento >RecuperaInvestimento()
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

        /*[HttpPut("{id}")]
        public IActionResult AtualizarPorId(int id, [FromBody] Investimento investimentonovo)
        {
            Investimento investimento = _context.Investimentos.FirstOrDefault(investimento => investimento.Id == id);
            if (investimento == null)
            {
                return NotFound();
            }
            investimento.Cliente = investimentonovo.Cliente;
            investimento.Lucro = investimentonovo.Lucro;
            investimento.TempoEmDias = investimentonovo.TempoEmDias;
            investimento.TempoEmAnos = investimentonovo.TempoEmAnos;
            investimento.DataDeInicio = investimentonovo.DataDeInicio;
            investimento.DataDeResgate = investimentonovo.DataDeResgate;

            _context.SaveChanges();
            return NoContent();
        }*/
        [HttpDelete("{id}")]
        public IActionResult DeletaPorId(int id)
        {
            Investimento investimento = _context.Investimentos.FirstOrDefault(investimento => investimento.Id == id);
            if (investimento != null)
            {
                _context.Remove(investimento);
                _context.SaveChanges();
            }
            return NotFound();
        }


        [HttpPut("{id}")]
        public IActionResult TudoPorId(int id)
        {
            Investimento investimento = _context.Investimentos.FirstOrDefault(investimento => investimento.Id == id);
            TimeSpan date = Convert.ToDateTime(investimento.DataDeResgate) - Convert.ToDateTime(investimento.DataDeInicio);
            int totalDias = date.Days;

            investimento.TempoEmDias = totalDias;
            investimento.TempoEmAnos =  totalDias / 365;


            if (investimento == null || investimento.Lucro <= 0 || totalDias < 1)
            {
                return NotFound(); 
            }
            Ok(investimento);

            Double Imposto;
            if (365 <= totalDias)
            {
                Imposto = 0.225;
                Console.WriteLine("O imposto foi de : " + (Imposto) + " Sobre o lucro de " + (investimento.Lucro));
                Console.WriteLine("Totalizando " + (Imposto * investimento.Lucro) + " Reais de imposto, e lucro final de " + ((investimento.Lucro) - (Imposto * investimento.Lucro)));
            }
            else if (365 < totalDias && 365 * 2 >= totalDias)
            {
                Imposto = 0.185;
                Console.WriteLine("O imposto foi de : " + (Imposto) + " Sobre o lucro de " + (investimento.Lucro));
                Console.WriteLine("Totalizando " + (Imposto * investimento.Lucro) + " Reais de imposto, e lucro final de " + ((investimento.Lucro) - (Imposto * investimento.Lucro)));
            }
            else if (365 * 2 < totalDias)
            {
                Imposto = 0.15;
                Console.WriteLine("O imposto foi de : " + (Imposto) + " Sobre o lucro de " + (investimento.Lucro));
                Console.WriteLine("Totalizando " + (Imposto * investimento.Lucro) + " Reais de imposto, e lucro final de " + ((investimento.Lucro) - (Imposto * investimento.Lucro)));
            }
            return NoContent();
        }
    }
}

