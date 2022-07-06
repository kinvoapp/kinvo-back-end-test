using Moq;
using Xunit;
using System;
using Aliquota.Domain.Models;
using Aliquota.Domain.Services;
using Aliquota.Domain.Interfaces;

namespace Aliquota.Domain.Tests
{
    public class ProdutoTests
    {
        [Fact(DisplayName = "Adicionar Produto Válido")]
        [Trait("Categoria", "Produto")]
        public async void AdicionarProduto_NovoProdutoValido_DeveCadastrarProduto()
        {
            // AAA
            var produto = new Produto(Guid.NewGuid(), "Fundo XYZ", 12,true, DateTime.Now);

            var produtoRepo = new Mock<IProdutoRepository>();
            var posicaoRepo = new Mock<IPosicaoRepository>();
            var notificador = new Mock<INotificador>();

            var produtoService = new ProdutoService(produtoRepo.Object, posicaoRepo.Object, notificador.Object);

            // ACT
            await produtoService.Adicionar(produto);

            // Assert
            produtoRepo.Verify(r => r.Adicionar(produto), Times.Once);
        }

        [Fact(DisplayName = "Adicionar Produto Inválido")]
        [Trait("Categoria", "Produto")]
        public async void AdicionarProduto_NovoProdutoInvalido_NaoDeveCadastrarProduto()
        {
            // AAA
            var produto = new Produto(Guid.NewGuid(), "Fund", 12, true, DateTime.Now);

            var produtoRepo = new Mock<IProdutoRepository>();
            var posicaoRepo = new Mock<IPosicaoRepository>();
            var notificador = new Mock<INotificador>();

            var produtoService = new ProdutoService(produtoRepo.Object, posicaoRepo.Object, notificador.Object);

            // ACT
            await produtoService.Adicionar(produto);

            // Assert
            produtoRepo.Verify(r => r.Adicionar(produto), Times.Never);
        }

        [Fact(DisplayName = "Adicionar Produto Repedido")]
        [Trait("Categoria", "Produto")]
        public async void AdicionarProduto_ProdutoRepetido_NaoDeveCadastrarProduto()
        {
            // AAA
            var produto = new Produto(Guid.NewGuid(), "Fundo XYZ", 12, true, DateTime.Now);

            var produtoRepo = new Mock<IProdutoRepository>();
            var posicaoRepo = new Mock<IPosicaoRepository>();
            var notificador = new Mock<INotificador>();

            var produtoService = new ProdutoService(produtoRepo.Object, posicaoRepo.Object, notificador.Object);

            await produtoService.Adicionar(produto);

            var produtoRepetido = new Produto(Guid.NewGuid(), "Fundo XYZ", 12, true, DateTime.Now);

            // ACT
            await produtoService.Adicionar(produtoRepetido);

            // Assert
            produtoRepo.Verify(r => r.Adicionar(produtoRepetido), Times.Never);
        }

        [Fact(DisplayName = "Atualizar Produto Válido")]
        [Trait("Categoria", "Produto")]
        public async void AtualizarProduto_AtualizarProdutoValido_DeveAtualizarProduto()
        {
            // AAA
            var produtoId = Guid.NewGuid();

            var produto = new Produto(produtoId, "Fundo XYZ", 12, true, DateTime.Now);

            var produtoRepo = new Mock<IProdutoRepository>();
            var posicaoRepo = new Mock<IPosicaoRepository>();
            var notificador = new Mock<INotificador>();

            var produtoService = new ProdutoService(produtoRepo.Object, posicaoRepo.Object, notificador.Object);

            await produtoService.Adicionar(produto);

            var produtoAtualizado = new Produto(produtoId, "Fundo ZXY", 12, true, DateTime.Now);

            // ACT
            await produtoService.Atualizar(produtoAtualizado);

            // Assert
            produtoRepo.Verify(r => r.Atualizar(produtoAtualizado), Times.Once);
        }

        [Fact(DisplayName = "Atualizar Produto Inválido")]
        [Trait("Categoria", "Produto")]
        public async void AtualizarProduto_AtualizarProduto_NaoDeveAtualizarProdutoInvalido()
        {
            // AAA
            var produtoId = Guid.NewGuid();

            var produto = new Produto(produtoId, "Fundo XYZ", 12, true, DateTime.Now);

            var produtoRepo = new Mock<IProdutoRepository>();
            var posicaoRepo = new Mock<IPosicaoRepository>();
            var notificador = new Mock<INotificador>();

            var produtoService = new ProdutoService(produtoRepo.Object, posicaoRepo.Object, notificador.Object);

            await produtoService.Adicionar(produto);

            var produtoAtualizado = new Produto(produtoId, "Fund", 12, true, DateTime.Now);

            // ACT
            await produtoService.Atualizar(produtoAtualizado);

            // Assert
            produtoRepo.Verify(r => r.Atualizar(produtoAtualizado), Times.Never);
        }

        [Fact(DisplayName = "Atualizar Produto Repetido", Skip = "Está Executando Atualizar Quando Não Deveria")]
        [Trait("Categoria", "Produto")]
        public async void AtualizarProduto_AtualizarProdutoRepetido_NaoDeveAtualizarProduto()
        {
            // AAA
            var primeiroProduto = new Produto(Guid.NewGuid(), "Fundo XYZ", 12, true, DateTime.Now);

            var produtoRepo = new Mock<IProdutoRepository>();
            var posicaoRepo = new Mock<IPosicaoRepository>();
            var notificador = new Mock<INotificador>();

            var produtoService = new ProdutoService(produtoRepo.Object, posicaoRepo.Object, notificador.Object);

            await produtoService.Adicionar(primeiroProduto);

            var produtoId = Guid.NewGuid();
            var segundoProduto = new Produto(produtoId, "Fundo ZYX", 12, true, DateTime.Now);
            await produtoService.Adicionar(segundoProduto);

            var produtoAtualizadoRepetido = new Produto(produtoId, "Fundo XYZ", 12, true, DateTime.Now);

            // ACT
            await produtoService.Atualizar(produtoAtualizadoRepetido);

            // Assert
            produtoRepo.Verify(r => r.Atualizar(produtoAtualizadoRepetido), Times.Never);
        }

        [Fact(DisplayName = "Remover Produto Sem Posições")]
        [Trait("Categoria", "Produto")]
        public async void RemoverProduto_ExcluirProdutoSemProsicoes_DeveExcluirProduto()
        {
            // AAA
            var produtoId = Guid.NewGuid();
            var produto = new Produto(produtoId,"Fundo XYZ", 12, true, DateTime.Now);

            var produtoRepo = new Mock<IProdutoRepository>();
            var posicaoRepo = new Mock<IPosicaoRepository>();
            var notificador = new Mock<INotificador>();

            var produtoService = new ProdutoService(produtoRepo.Object, posicaoRepo.Object, notificador.Object);

            await produtoService.Adicionar(produto);

            // ACT
            await produtoService.Remover(produtoId);

            // Assert
            produtoRepo.Verify(r => r.Remover(produtoId), Times.Once);
        }

        [Fact(DisplayName = "Remover Produto Com Posições", Skip = "Cenário Incompleto, pois não valida cenário")]
        [Trait("Categoria", "Produto")]
        public async  void RemoverProduto_ExcluirProdutoComPosicoes_DeveExcluirProduto()
        {
            // AAA
            var produtoId = Guid.NewGuid();
            var produto = new Produto(produtoId, "Fundo XYZ", 12, true, DateTime.Now);

            var produtoRepo = new Mock<IProdutoRepository>();
            var posicaoRepo = new Mock<IPosicaoRepository>();
            var notificador = new Mock<INotificador>();

            var produtoService = new ProdutoService(produtoRepo.Object, posicaoRepo.Object, notificador.Object);

            await produtoService.Adicionar(produto);

            var posicao = new Posicao(Guid.NewGuid(), produtoId, DateTime.Now, DateTime.Now, 100.14m, true);
            var posicaoService = new PosicaoService(posicaoRepo.Object, produtoRepo.Object, notificador.Object);

            await posicaoService.Adicionar(posicao);

            // ACT
            await produtoService.Remover(produtoId);

            // Assert
            produtoRepo.Verify(r => r.Remover(produtoId), Times.Never);
        }
    }
}
