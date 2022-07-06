using Moq;
using Xunit;
using System;
using Aliquota.Domain.Interfaces;
using Aliquota.Domain.Models;
using Aliquota.Domain.Services;


namespace Aliquota.Domain.Tests
{
    public class PosicaoTests
    {
        [Fact(DisplayName = "Adicionar Posição Válida")]
        [Trait("Categoria", "Posicao")]
        public async void AdicionarPosicao_NovoPosicaoValida_DeveCadastrarPosicao()
        {
            // AAA
            var posicao = new Posicao(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, DateTime.Now, 100.14m, true);

            var posicaoRepo = new Mock<IPosicaoRepository>();
            var produtoRepo = new Mock<IProdutoRepository>();
            var notificador = new Mock<INotificador>();

            var posicaoService = new PosicaoService(posicaoRepo.Object, produtoRepo.Object, notificador.Object);

            // ACT
            await posicaoService.Adicionar(posicao);

            // Assert
            posicaoRepo.Verify(r => r.Adicionar(posicao), Times.Once);
        }

        [Fact(DisplayName = "Adicionar Posição Invalida")]
        [Trait("Categoria", "Posicao")]
        public async void AdicionarPosicao_NovoPosicaoInalida_NaoDeveCadastrarPosicao()
        {
            // AAA
            var posicao = new Posicao(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, DateTime.Now, 0, true);

            var posicaoRepo = new Mock<IPosicaoRepository>();
            var produtoRepo = new Mock<IProdutoRepository>();
            var notificador = new Mock<INotificador>();

            var posicaoService = new PosicaoService(posicaoRepo.Object, produtoRepo.Object, notificador.Object);

            // ACT
            await posicaoService.Adicionar(posicao);

            // Assert
            posicaoRepo.Verify(r => r.Adicionar(posicao), Times.Never);
        }


        [Fact(DisplayName = "Atualizar Posição Válida")]
        [Trait("Categoria", "Posicao")]
        public async void AtualizarPosicao_AtualizarPosicaoValida_DeveAtualizarPosicao()
        {
            // AAA
            var produtoId = Guid.NewGuid();
            var posicaoId = Guid.NewGuid();

            var posicao = new Posicao(produtoId, posicaoId, DateTime.Now, DateTime.Now, 100, true);

            var posicaoRepo = new Mock<IPosicaoRepository>();
            var produtoRepo = new Mock<IProdutoRepository>();
            var notificador = new Mock<INotificador>();

            var posicaoService = new PosicaoService(posicaoRepo.Object, produtoRepo.Object, notificador.Object);

            await posicaoService.Adicionar(posicao);

            var posicaoAtualizada = new Posicao(produtoId, posicaoId, DateTime.Now, DateTime.Now, 100, false);


            // ACT
            await posicaoService.Atualizar(posicaoAtualizada);

            // Assert
            posicaoRepo.Verify(r => r.Atualizar(posicaoAtualizada), Times.Once);
        }

        [Fact(DisplayName = "Atualizar Posição Inválida")]
        [Trait("Categoria", "Posicao")]
        public async void AtualizarPosicao_AtualizarPosicaoInalida_NaoDeveAtualizarPosicao()
        {
            // AAA
            var produtoId = Guid.NewGuid();
            var posicaoId = Guid.NewGuid();

            var posicao = new Posicao(produtoId, posicaoId, DateTime.Now, DateTime.Now, 0, true);

            var posicaoRepo = new Mock<IPosicaoRepository>();
            var produtoRepo = new Mock<IProdutoRepository>();
            var notificador = new Mock<INotificador>();

            var posicaoService = new PosicaoService(posicaoRepo.Object, produtoRepo.Object, notificador.Object);

            await posicaoService.Adicionar(posicao);

            var posicaoAtualizada = new Posicao(produtoId, posicaoId, DateTime.Now, DateTime.Now, 0m, false);

            
            // ACT
            await posicaoService.Atualizar(posicaoAtualizada);

            // Assert
            posicaoRepo.Verify(r => r.Atualizar(posicaoAtualizada), Times.Never);
        }

        [Fact(DisplayName = "Remover Posição Válida")]
        [Trait("Categoria", "Posicao")]
        public async void RemoverPosicao_RemoverPosicaoValida_DeveRemoverPosicao()
        {
            // AAA
            var posicaoId = Guid.NewGuid();

            var posicao = new Posicao(posicaoId, Guid.NewGuid(), DateTime.Now, DateTime.Now, 100.14m, true);

            var posicaoRepo = new Mock<IPosicaoRepository>();
            var produtoRepo = new Mock<IProdutoRepository>();
            var notificador = new Mock<INotificador>();

            var posicaoService = new PosicaoService(posicaoRepo.Object, produtoRepo.Object, notificador.Object);

            // ACT
            await posicaoService.Remover(posicaoId);

            // Assert
            posicaoRepo.Verify(r => r.Remover(posicaoId), Times.Once);
        }

        [Fact(DisplayName = "Remover Posição Inválida")]
        [Trait("Categoria", "Posicao")]
        public async void RemoverPosicao_RemoverPosicaoInvalida_NaoDeveRemoverPosicao()
        {
            // AAA
            var posicaoId = Guid.NewGuid();

            var posicao = new Posicao(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, DateTime.Now, 100.14m, true);

            var posicaoRepo = new Mock<IPosicaoRepository>();
            var produtoRepo = new Mock<IProdutoRepository>();
            var notificador = new Mock<INotificador>();

            var posicaoService = new PosicaoService(posicaoRepo.Object, produtoRepo.Object, notificador.Object);

            // ACT
            await posicaoService.Remover(posicaoId);

            // Assert
            posicaoRepo.Verify(r => r.Remover(posicaoId), Times.Once);
        }

    }
}
