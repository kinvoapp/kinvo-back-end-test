using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Aliquota.Domain.Models;
using Aliquota.API.ViewModels;
using Aliquota.Domain.Interfaces;

namespace Aliquota.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PosicoesController : MainController
    {
        private readonly IPosicaoRepository _posicaoRepository;
        private readonly IPosicaoService _posicaoService;
        private readonly IMapper _mapper;

        public PosicoesController(INotificador notificador,
                                  IPosicaoRepository posicaoRepository,
                                  IPosicaoService posicaoService,
                                  IMapper mapper) : base(notificador)
        {
            _posicaoRepository = posicaoRepository;
            _posicaoService = posicaoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PosicaoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<PosicaoViewModel>>(await _posicaoRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PosicaoViewModel>> ObterPorId(Guid id)
        {
            var produtoViewModel = await ObterPosicao(id);

            if (produtoViewModel == null) return NotFound();

            return produtoViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<PosicaoViewModel>> Adicionar(PosicaoViewModel posicaoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _posicaoService.Adicionar(_mapper.Map<Posicao>(posicaoViewModel));

            return CustomResponse(posicaoViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, PosicaoViewModel posicaoViewModel)
        {
            if (id != posicaoViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(posicaoViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _posicaoService.Atualizar(_mapper.Map<Posicao>(posicaoViewModel));

            return CustomResponse(posicaoViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<PosicaoViewModel>> Excluir(Guid id)
        {
            var posicaoViewModel = await ObterPosicao(id);

            if (posicaoViewModel == null) return NotFound();

            await _posicaoService.Remover(id);

            return CustomResponse(posicaoViewModel);
        }

        private async Task<PosicaoViewModel> ObterPosicao(Guid id)
        {
            return _mapper.Map<PosicaoViewModel>(await _posicaoRepository.ObterProdutoPosicao(id));
        }
    }
}
