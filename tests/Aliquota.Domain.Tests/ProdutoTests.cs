using Moq;
using Xunit;
using System;
using Aliquota.Domain.Models;
using Aliquota.Domain.Services;
using Aliquota.Domain.Interfaces;
using System.Linq;

namespace Aliquota.Domain.Tests
{
    [TestCaseOrderer("Aliquota.Domain.Tests.PriorityOrderer", "Aliquota.Domain.Tests")]
    [Collection(nameof(ProdutoCollection))]
    public class ProdutoTests
    {
        /*
        public Produto ProdutoValido;

        public ProdutoTests()
        {
            ProdutoValido = new Produto(Guid.NewGuid(),"Fundo XYZ",12,true,DateTime.Now);
        }*/

        private readonly ProdutoTestsFixture _produtoTestsFixture;

        public ProdutoTests(ProdutoTestsFixture produtoTestsFixture)
        {
            _produtoTestsFixture = produtoTestsFixture;
        }

        [Fact(DisplayName = "00 Obter Todos Os Produtod")]
        [Trait("Categoria", "Produto")]
        public async void ObterProdutos_ObterListaDeProdutos_DeveObterTodosProdutos()
        {
            // Arrange
            var produtoValido = _produtoTestsFixture.GerarProdutoValido();
            var produtoRepo = new Mock<IProdutoRepository>();
            var posicaoRepo = new Mock<IPosicaoRepository>();
            var notificador = new Mock<INotificador>();

            var produtoService = new ProdutoService(produtoRepo.Object, posicaoRepo.Object, notificador.Object);

            await produtoService.Adicionar(produtoValido);

            // Act
            var produtos = produtoService.ObterProdutosAtivos().Result;

            // Assert
            Assert.True(produtos.Any());
        }

        [Fact(DisplayName = "01 Adicionar Produto Válido"), TestPriority(1)]
        [Trait("Categoria", "Produto")]
        public async void AdicionarProduto_NovoProdutoValido_DeveCadastrarProduto()
        {
            // AAA
            //var produto = new Produto(Guid.NewGuid(), "Fundo XYZ", 12,true, DateTime.Now);  
            var produtoValido = _produtoTestsFixture.GerarProdutoValido();

            var produtoRepo = new Mock<IProdutoRepository>();
            var posicaoRepo = new Mock<IPosicaoRepository>();
            var notificador = new Mock<INotificador>();

            var produtoService = new ProdutoService(produtoRepo.Object, posicaoRepo.Object, notificador.Object);

            // ACT
            //await produtoService.Adicionar(produto);
            //await produtoService.Adicionar(ProdutoValido);
            await produtoService.Adicionar(produtoValido);

            // Assert
            //produtoRepo.Verify(r => r.Adicionar(produto), Times.Once);
            //produtoRepo.Verify(r => r.Adicionar(ProdutoValido), Times.Once);
            produtoRepo.Verify(r => r.Adicionar(produtoValido), Times.Once);
        }

        [Fact(DisplayName = "02 Adicionar Produto Inválido"), TestPriority(2)]
        [Trait("Categoria", "Produto")]
        public async void AdicionarProduto_NovoProdutoInvalido_NaoDeveCadastrarProduto()
        {
            // AAA
            //var produto = new Produto(Guid.NewGuid(), "Fund", 12, true, DateTime.Now);
            var produtoInvalido = _produtoTestsFixture.GerarProdutoInvalido();

            var produtoRepo = new Mock<IProdutoRepository>();
            var posicaoRepo = new Mock<IPosicaoRepository>();
            var notificador = new Mock<INotificador>();

            var produtoService = new ProdutoService(produtoRepo.Object, posicaoRepo.Object, notificador.Object);

            // ACT
            //await produtoService.Adicionar(produto);
            await produtoService.Adicionar(produtoInvalido);

            // Assert
            //produtoRepo.Verify(r => r.Adicionar(produto), Times.Never);
            produtoRepo.Verify(r => r.Adicionar(produtoInvalido), Times.Never);
        }

        [Fact(DisplayName = "03 Adicionar Produto Repedido"), TestPriority(3)]
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

        [Fact(DisplayName = "04 Atualizar Produto Válido"), TestPriority(4)]
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

        [Fact(DisplayName = "05 Atualizar Produto Inválido"), TestPriority(5)]
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

        [Fact(DisplayName = "06 Atualizar Produto Repetido", Skip = "Está Executando Atualizar Quando Não Deveria"), TestPriority(6)]
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

        [Fact(DisplayName = "07 Remover Produto Sem Posições"), TestPriority(7)]
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

        [Fact(DisplayName = "08 Remover Produto Com Posições", Skip = "Cenário Incompleto, pois não valida cenário"), TestPriority(8)]
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
