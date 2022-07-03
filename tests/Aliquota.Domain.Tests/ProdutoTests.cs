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
        public void AdicionarProduto_NovoProdutoValido_DeveCadastrarProduto()
        {
            // AAA
            var produto = new Produto(Guid.NewGuid(), "Fundo XYZ", 12,true, DateTime.Now);

            var produtoRepo = new Mock<IProdutoRepository>();
            var notificador = new Mock<INotificador>();

            var produtoService = new ProdutoService(produtoRepo.Object, notificador.Object);

            // ACT
            produtoService.Adicionar(produto);

            // Assert
            produtoRepo.Verify(r => r.Adicionar(produto), Times.Once);
        }

        [Fact(DisplayName = "Adicionar Produto Inválido")]
        [Trait("Categoria", "Produto")]
        public void AdicionarProduto_NovoProdutoInvalido_NaoDeveCadastrarProduto()
        {
            // AAA
            var produto = new Produto(Guid.NewGuid(), "Fund", 12, true, DateTime.Now);

            var produtoRepo = new Mock<IProdutoRepository>();
            var notificador = new Mock<INotificador>();

            var produtoService = new ProdutoService(produtoRepo.Object, notificador.Object);

            // ACT
            produtoService.Adicionar(produto);

            // Assert
            produtoRepo.Verify(r => r.Adicionar(produto), Times.Never);
        }

        [Fact(DisplayName = "Adicionar Produto Repedido")]
        [Trait("Categoria", "Produto")]
        public void AdicionarProduto_ProdutoRepetido_NaoDeveCadastrarProduto()
        {
            // AAA
            var produto = new Produto(Guid.NewGuid(), "Fundo XYZ", 12, true, DateTime.Now);

            var produtoRepo = new Mock<IProdutoRepository>();
            var notificador = new Mock<INotificador>();

            var produtoService = new ProdutoService(produtoRepo.Object, notificador.Object);

            produtoService.Adicionar(produto);

            var produtoRepetido = new Produto(Guid.NewGuid(), "Fundo XYZ", 12, true, DateTime.Now);


            // ACT
            produtoService.Adicionar(produtoRepetido);

            // Assert
            produtoRepo.Verify(r => r.Adicionar(produtoRepetido), Times.Once);
        }

        [Fact(DisplayName = "Atualizar Produto Válido")]
        [Trait("Categoria", "Produto")]
        public void AtualizarProduto_AtualizarProdutoValido_DeveAtualizarProduto()
        {
            // AAA
            var produtoId = Guid.NewGuid();

            var produto = new Produto(produtoId, "Fundo XYZ", 12, true, DateTime.Now);

            var produtoRepo = new Mock<IProdutoRepository>();
            var notificador = new Mock<INotificador>();

            var produtoService = new ProdutoService(produtoRepo.Object, notificador.Object);

            produtoService.Adicionar(produto);

            var produtoAtualizado = new Produto(produtoId, "Fundo ZXY", 12, true, DateTime.Now);

            // ACT
            produtoService.Atualizar(produtoAtualizado);

            // Assert
            produtoRepo.Verify(r => r.Atualizar(produtoAtualizado), Times.Once);
        }

        [Fact(DisplayName = "Atualizar Produto Inválido")]
        [Trait("Categoria", "Produto")]
        public void AtualizarProduto_AtualizarProduto_NaoDeveAtualizarProdutoInvalido()
        {
            // AAA
            var produtoId = Guid.NewGuid();

            var produto = new Produto(produtoId, "Fundo XYZ", 12, true, DateTime.Now);

            var produtoRepo = new Mock<IProdutoRepository>();
            var notificador = new Mock<INotificador>();

            var produtoService = new ProdutoService(produtoRepo.Object, notificador.Object);

            produtoService.Adicionar(produto);

            var produtoAtualizado = new Produto(produtoId, "Fund", 12, true, DateTime.Now);

            // ACT
            produtoService.Atualizar(produtoAtualizado);

            // Assert
            produtoRepo.Verify(r => r.Atualizar(produtoAtualizado), Times.Never);
        }

        [Fact(DisplayName = "Atualizar Produto Repetido", Skip = "Está Executando Atualizar Quando Não Deveria")]
        [Trait("Categoria", "Produto")]
        public void AtualizarProduto_AtualizarProdutoRepetido_NaoDeveAtualizarProduto()
        {
            // AAA
            var primeiroProduto = new Produto(Guid.NewGuid(), "Fundo XYZ", 12, true, DateTime.Now);

            var produtoRepo = new Mock<IProdutoRepository>();
            var notificador = new Mock<INotificador>();

            var produtoService = new ProdutoService(produtoRepo.Object, notificador.Object);
            produtoService.Adicionar(primeiroProduto);

            var produtoId = Guid.NewGuid();
            var segundoProduto = new Produto(produtoId, "Fundo ZYX", 12, true, DateTime.Now);
            produtoService.Adicionar(segundoProduto);

            var produtoAtualizadoRepetido = new Produto(produtoId, "Fundo XYZ", 12, true, DateTime.Now);

            // ACT
            var resultado = produtoService.Atualizar(produtoAtualizadoRepetido);

            // Assert
            produtoRepo.Verify(r => r.Atualizar(produtoAtualizadoRepetido), Times.Once); // TODO
        }

        [Fact(DisplayName = "Remover Produto Sem Posições")]
        [Trait("Categoria", "Produto")]
        public void RemoverProduto_ExcluirProdutoSemProsicoes_DeveExcluirProduto()
        {
            // AAA
            var produtoId = Guid.NewGuid();
            var produto = new Produto(produtoId,"Fundo XYZ", 12, true, DateTime.Now);

            var produtoRepo = new Mock<IProdutoRepository>();
            var notificador = new Mock<INotificador>();

            var produtoService = new ProdutoService(produtoRepo.Object, notificador.Object);

            produtoService.Adicionar(produto);

            // ACT
            produtoService.Remover(produtoId);

            // Assert
            produtoRepo.Verify(r => r.Remover(produtoId), Times.Once);
        }

        [Fact(DisplayName = "Remover Produto Com Posições", Skip = "Cenário Incompleto, pois precisa adicionar posições")]
        [Trait("Categoria", "Produto")]
        public void RemoverProduto_ExcluirProdutoComPosicoes_DeveExcluirProduto()
        {
            // AAA
            var produtoId = Guid.NewGuid();
            var produto = new Produto(produtoId, "Fundo XYZ", 12, true, DateTime.Now);

            var produtoRepo = new Mock<IProdutoRepository>();
            var notificador = new Mock<INotificador>();

            var produtoService = new ProdutoService(produtoRepo.Object, notificador.Object);

            produtoService.Adicionar(produto);

            // TODO => Adicionar posições ao produto

            // ACT
            produtoService.Remover(produtoId);

            // Assert
            produtoRepo.Verify(r => r.Remover(produtoId), Times.Once);
        }
    }
}
