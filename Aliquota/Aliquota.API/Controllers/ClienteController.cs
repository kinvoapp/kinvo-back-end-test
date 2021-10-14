using Aliquota.Data.Contratos;
using Aliquota.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Aliquota.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public readonly IGeralPersist _context;
        public readonly IClientePersist _contextClient;
        public ClienteController(IGeralPersist context, IClientePersist contextClient)
        {
            _context = context;
            _contextClient = contextClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var Clientes = await _contextClient.GetAllClientes();
                return Ok(Clientes);
            }
            catch (Exception)
            {
                return BadRequest("Não deu bom");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var cliente = await _contextClient.GetClienteById(id);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cliente cliente)
        {
            try
            {
                _context.Add(cliente);
                if(await _context.SaveChangesAsync())
                {
                    return Ok("Deu certo");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao salvar");
            }

            return BadRequest("Falha ao salvar");
        }

        [HttpGet("{id}/{tempoDeInvestimento}/{valorResgate}")]
        public async Task<IActionResult> Resgatar(int id, double valorResgate, int tempoDeInvestimento)
        {
            var cliente = await _contextClient.GetClienteById(id);

            var valorInvestido = 1000000000;
            var valorBruto = 15951512151511595;
            var valorResgatado = valorResgate;

            double lucro = valorBruto - valorInvestido;

            ComprovanteResgate comprovante = new ComprovanteResgate();

            var valorResgatadoTotal = await _contextClient.Resgatar(valorBruto, valorInvestido, valorResgatado, lucro, tempoDeInvestimento, id, comprovante);

            return Ok(valorResgatadoTotal);
        }
    }
}
