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
            var posicao = new Posicao(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, DateTime.Now, 100, true);

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


    }
}
