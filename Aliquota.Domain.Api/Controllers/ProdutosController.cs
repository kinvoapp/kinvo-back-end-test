using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aliquota.Domain.Context;
using Aliquota.Domain.Models;
using Aliquota.Domain.Api.Services;
using Aliquota.Domain.Api.ViewModel;

namespace Aliquota.Domain.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly SqliteContext _context;

        public ProdutosController(SqliteContext context)
        {
            _context = context;
        }
        //Listar Produtos
        // GET: api/Produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            try
            {
                return await _context.Produtos.Where(x=>x.DataResgate == new DateTime()).ToListAsync();
            }
            catch (Exception)
            {

                return NotFound(new
                {
                    Status = 2,
                    Message = "Não é possivel listar Produtos"
                });
            }

        }

        // Resgate Produto
        // GET: api/Produtos/Resgate/5
        [HttpGet("Resgate/{id}")]
        public async Task<ActionResult> GetProduto(Guid id)
        {
            // Request - Status { 0 = Não é possivel o resgate, 1 = OK o resgate, 2 = resgate imcompleto ,
            try
            {
                var produto = await _context.Produtos.FindAsync(id);
                var meses = Meses.Contar(produto.DataCriacao);
               
                if (meses >= 0)
                {
                    //Chama a operação de Resgate do Produto
                    ResultResgate result = Operacao.Resgate(produto.Tipo, meses, produto.ValorAplcado, produto.Porcentagem);
                   

                    produto.DataResgate = DateTime.Now;

                    _context.SaveChanges();

                    return Ok(new
                    {
                        Status = 1,
                        result
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        Status = 0,
                        Message = "Não é possivel o resgate, pois data de resgate menor que data de aplicação"
                    });

                }
;
            }
            catch (Exception)
            {

                return NotFound(new
                {
                    Status = 2,
                    Message = "Não é possivel o resgate, pois data de resgate menor que data de aplicação"
                });
            }
        }

        //Criar Produto
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(decimal valorAplcado, Tipo tipo, decimal porcentagem, DateTime dataCriacao)
        {
            try
            {
                Produto produto = new Produto() { Id = Guid.NewGuid(), Tipo = tipo, ValorAplcado = valorAplcado, Porcentagem = porcentagem, DataCriacao = dataCriacao, DataResgate = new DateTime() };
                _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetProduto", new { id = produto.Id }, produto);
            }
            catch (Exception)
            {

                return NotFound(new
                {
                    Status = 2,
                    Message = "Não é possivel o cadastrar Produto"
                });
            }
        }
    }
}
