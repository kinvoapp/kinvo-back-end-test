using Aliquota.Dominio.Entidades;
using Aliquota.Dominio.Servicoes;
using Aliquota.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Controllers
{
    [ApiController]
    [Route(template: "V1")]
    public class AliquotaController : ControllerBase
    {
        private readonly IAliquotaServico _aliquotaServico;
        public AliquotaController(DataContext context,
            IAliquotaServico aliquotaServico)
        {
            _aliquotaServico = aliquotaServico;
        }

        /*
         *  porta: https://localhost:5001/
        */

        //Post/v1/clientes -> Cadastra um cliente
        [HttpPost("clientes")]
        public async Task<IActionResult> InserirCliente([FromBody] Cliente cliente)
        {
            var result = _aliquotaServico.InserirCliente(cliente);
            if (result.IsValid)
            {
                await _aliquotaServico.SaveAsync();
                return Ok(cliente);
            }
            return BadRequest(result.Errors);
        }

        //Delete /v1/clientes{clienteId} -> Exclui um cliente *obs* o metodo não deleta do banco para o caso de precisar restaurar
        [HttpDelete("clientes/{clienteId}")]
        public async Task<IActionResult> DeleteClienteAsync(int clienteId)
        {
            var result = await _aliquotaServico.DeleteClienteAsync(clienteId);
            if (result != null)
            {
                await _aliquotaServico.SaveAsync();
                return Ok(result);

            }
            return NotFound();
        }

        //Put /V1/clientes{clienteId} -> Atualiza os dados cadastrados de um cliente
        [HttpPut("clientes/{clienteId}")]
        public async Task<IActionResult> AtualizarClienteAsync(int clienteId,Cliente cliente)
        {
            if (cliente.ClienteId != clienteId)
            {
                return BadRequest("clienteId está invalido");
            }

            var result = await _aliquotaServico.AtualizarClienteAsync(cliente);
            if (result.IsValid)
            {
                await _aliquotaServico.SaveAsync();
                return Ok(cliente);

            }
            return BadRequest();
        }

        //Get /v1/clientes -> Obtem todos clientes cadastrados /v1/clientes?excluidos=true -> obtem somente os clientes excluidos
        [HttpGet("clientes")]
        public async Task<IActionResult> ObterClientesAsync(bool excluidos)
        {
            if (excluidos)
            {
                var result = await _aliquotaServico.ObterClientesSomenteExcluidosAsync();
                return Ok(result);
            }

            var todos = await _aliquotaServico.ObterTodosClientesAsync();
            return Ok(todos);
        }

        //Get /v1/clientes/{clienteId} -> obtem um cliente pelo id 
        [HttpGet("clientes/{clienteId}")]
        public async Task<IActionResult> ObterInventarioPorIdAsync(int clienteId)
        {
            var result = await _aliquotaServico.ObterClientePorIdAsync(clienteId);
            return result == null
                  ? NotFound()
                  : Ok(result);
        }

        //Put /v1/clients/{clientesId}/excluidos?restaurarcliente=true -> Restaura os clientes excluidos
        [HttpPut("clientes/{clienteId}/excluidos")]
        public async Task<IActionResult> RestaurarClienteAsync(bool restaurarcliente, int clienteId)
        {
            if (restaurarcliente)
            {
                var result = await _aliquotaServico.RestaurarClienteAsync(clienteId);
                await _aliquotaServico.SaveAsync();
                return Ok(result);
            }

            return BadRequest();

        }
        
        //Post/v1/clientes -> Inserir ou remover saldo da carteira
        [HttpPost("{clienteId}/carteira")]
        public async Task<IActionResult> InserirCarteira([FromBody] Carteira carteira, int clienteId)
        {
            var result = _aliquotaServico.AdicionarCarteira(carteira, clienteId);
            if (result.IsValid)
            {
                await _aliquotaServico.SaveAsync();
                return Ok(carteira);
            }
            return BadRequest(result.Errors);
        }
        
        //Post/v1/produtofinanceiro -> Cadastra um Produto Financeiro
        [HttpPost("{clienteId}/produtofinanceiro")]
        public async Task<IActionResult> InserirProdutoFinanceiro([FromBody] ProdutoFinanceiro produtoFinanceiro, int clienteId)
        {
            var result = _aliquotaServico.InserirProdutoFinanceiro(produtoFinanceiro, clienteId);
            if (result.IsValid)
            {
                await _aliquotaServico.SaveAsync();
                return Ok(produtoFinanceiro);
            }
            return BadRequest(result.Errors);
        }

        //Post/v1/produtofinanceiro/aplicacao -> Faz uma aplicacao
        [HttpPost("{clienteId}/produtofinanceiro/{produtoFinanceiroId}/aplicacao")]
        public async Task<IActionResult> InserirAplicacao([FromBody] Aplicacao aplicacao, int clienteId, int produtoFinanceiroId)
        {

            var result = _aliquotaServico.InserirAplicacao(aplicacao,clienteId,produtoFinanceiroId);   
            if (result.IsValid)
            {
                await _aliquotaServico.SaveAsync();
                return Ok(aplicacao);
            }
            return BadRequest();
        }

        //Post/v1/produtofinanceiro/aplicacao -> Faz um Resgate
        [HttpPost("{clienteId}/produtofinanceiro/{produtoFinanceiroId}/resgate")]
        public async Task<IActionResult> InserirResgate([FromBody] Resgate resgate, int clienteId, int produtoFinanceiroId)
        {

            var result = _aliquotaServico.InserirResgate(resgate, produtoFinanceiroId, clienteId);
            if (result.IsValid)
            {
                await _aliquotaServico.SaveAsync();
                return Ok(resgate);
            }
            return BadRequest();
        }


    }
}
