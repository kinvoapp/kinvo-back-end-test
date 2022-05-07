using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aliquota.App.Data;
using Aliquota.App.ViewModels;
using AutoMapper;
using Aliquota.Domain.Interfaces;
using Aliquota.Domain.Models;

namespace Aliquota.App.Controllers
{
    public class PosicoesController : BaseController
    {
        private readonly IPosicaoRepository _posicaoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPosicaoService _posicaoService;
        private readonly IMapper _mapper;

        public PosicoesController(IPosicaoRepository posicaoRepository,
                                  IProdutoRepository produtoRepository,
                                  IPosicaoService posicaoService,                                                                 
                                  INotificador notificador,
                                  IMapper mapper) : base(notificador)
        {
            _posicaoRepository = posicaoRepository;
            _produtoRepository = produtoRepository;
            _posicaoService = posicaoService;
            _mapper = mapper;
        }

        // GET: Posicoes
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<PosicaoViewModel>>(await _posicaoRepository.ObterTodos()));
        }

        // GET: Posicoes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var posicaoViewModel = await ObterPosicao(id);

            if (posicaoViewModel == null) return NotFound();
            
            return View(posicaoViewModel);
        }

        // GET: Posicoes/Create
        public async Task<IActionResult> Create()
        {
            var posicaoViewModel = await PopularProdutos(new PosicaoViewModel());

            return View(posicaoViewModel);
        }

        // POST: Posicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PosicaoViewModel posicaoViewModel)
        {
            posicaoViewModel = await PopularProdutos(posicaoViewModel);

            if (!ModelState.IsValid) return View(posicaoViewModel);

            await _posicaoService.Adicionar(_mapper.Map<Posicao>(posicaoViewModel));

            if (!OperacaoValida()) return View(posicaoViewModel);

            return RedirectToAction("Index");
        }

        // GET: Posicoes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var posicaoViewModel = await ObterPosicao(id);

            if (posicaoViewModel == null) return NotFound();

            return View(posicaoViewModel);
        }

        // POST: Posicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PosicaoViewModel posicaoViewModel)
        {
            if (id != posicaoViewModel.Id) return NotFound();

            var posicaoAtualizacao = await ObterPosicao(id);
            posicaoViewModel.Produtos = posicaoAtualizacao.Produtos;

            if (!ModelState.IsValid) return View(posicaoViewModel);

            posicaoAtualizacao.ValorAportado = posicaoViewModel.ValorAportado;
            posicaoAtualizacao.ValorResgatado = posicaoViewModel.ValorResgatado;
            posicaoAtualizacao.ValorTributado = posicaoViewModel.ValorTributado;
            posicaoAtualizacao.DataAporte = posicaoViewModel.DataAporte;
            posicaoAtualizacao.DataResgate = posicaoViewModel.DataResgate;
            posicaoAtualizacao.Ativo = posicaoViewModel.Ativo;

            await _posicaoService.Atualizar(_mapper.Map<Posicao>(posicaoAtualizacao));

            if (!OperacaoValida()) return View(posicaoViewModel);

            return RedirectToAction("Index");
        }

        // GET: Posicoes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var posicao = await ObterPosicao(id);

            if (posicao == null) return NotFound();

            return View(posicao);
        }

        // POST: Posicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var posicao = await ObterPosicao(id);

            if (posicao == null) return NotFound();
            
            await _posicaoService.Remover(id);

            if (!OperacaoValida()) return View(posicao);

            TempData["Sucesso"] = "Posicao excluida com sucesso!";

            return RedirectToAction("Index");
        }

        private async Task<PosicaoViewModel> ObterPosicao(Guid id)
        {
            var posicao = _mapper.Map<PosicaoViewModel>(await _posicaoRepository.ObterPorId(id));
            return posicao;
        }

        private async Task<PosicaoViewModel> PopularProdutos(PosicaoViewModel posicao)
        {
            posicao.Produtos = _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterTodos());
            return posicao;
        }
    }
}
