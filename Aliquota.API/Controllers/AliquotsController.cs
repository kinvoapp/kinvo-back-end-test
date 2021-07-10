using Microsoft.AspNetCore.Mvc;

using Aliquota.Domain.Service.Interfaces;
using Aliquota.Domain.DTO;


namespace Aliquota.API.Controllers
{
    [ApiController]
    [Route("api/aliquots")]
    public class AliquotsController : ControllerBase
    {
        private readonly IAliquotService _aliquotService;
        private readonly IClientService _clientService;

        public AliquotsController(IAliquotService aliquotService, IClientService clientService)
        {
            _aliquotService = aliquotService;
            _clientService = clientService;
        }

        /// <summary>
        /// Retorna uma aplicacao utilizando o id como parametro de busca
        /// </summary>
        /// <param name="id">Id da aplicacao</param>
        /// <returns>Retorna uma aplicacao</returns>
        /// <response code="200">Aplicacao retornada com sucesso</response>
        /// <response code="404">"Nao existe nenhuma aplicacao registrada para este id"</response>
        [HttpGet("{id}")]
        public IActionResult GetApplication(int id)
        {
            var application = _aliquotService.GetApplication(id);

            if (application != null)
            {
                return Ok(application);
            }
            return NotFound();
        }

        /// <summary>
        /// Realiza uma nova aplicacao
        /// </summary>
        /// <param name="applicationDTO">Dados da aplicacao</param>
        /// <returns>Informacoes da aplicacao registrada</returns>
        /// <response code="200">Aplicacao realizada com sucesso</response>
        /// <response code="400">Informacoes da aplicacao nao esta no padrao</response>
        /// <response code="500">Internal Exception</response>
        [HttpPost]
        public IActionResult Apply(ApplicationDTO applicationDTO)
        {
            if (ModelState.IsValid)
            {
                var client = _clientService.GetByDocument(applicationDTO.Document);

                var application = _aliquotService.Apply(applicationDTO);

                return Ok(application);
            }

            return BadRequest();
        }

        /// <summary>
        /// Peforms a withdraw
        /// </summary>
        /// <param name="withdraw">data of application</param>
        /// <returns>Withdraw</returns>
        /// <response code="200">Aplicacao realizada com sucesso</response>
        /// <response code="400">Informacoes da aplicacao nao esta no padrao</response>
        /// <response code="500">Internal Exception</response>
        [HttpPatch]
        public IActionResult Withdraw([FromBody] RequestWithdrawDTO withdraw)
        {

            var application = _aliquotService.Withdraw(withdraw);
            return Ok(application);

        }

        /// <summary>
        /// Adiciona um novo client
        /// </summary>
        /// <param name="clientDTO">Informacoes do client para ser cadastrado</param>
        /// <returns>Novo client</returns>
        /// <response code="200">Usuario criado com sucesso</response>
        /// <response code="400">Informacoes do client nao esta no padrao</response>
        [HttpPost("client")]
        public IActionResult Add([FromBody] ClientDTO clientDTO)
        {
            if (!_clientService.VerifyIfExists(clientDTO))
            {

                ClientDTO client = _clientService.Add(clientDTO);

                return Ok(client);
            }
            return BadRequest("Client already exists");

        }

    }
}