using Aliquota.Domain.Entities;
using Aliquota.Domain.Interfaces.Repositories;
using Aliquota.Infrasctructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Xunit;

namespace Aliquota.Infrasctructure.Test
{
    public class MovimentacaoRepositorioTestes
    {

        private readonly IMovimentacaoRepositorio _repositorio;

        public MovimentacaoRepositorioTestes()
        {
            var servico = new ServiceCollection();
            servico.AddTransient<IMovimentacaoRepositorio, MovimentacaoRepositorio>();
            var provedor = servico.BuildServiceProvider();
            _repositorio = provedor.GetService<IMovimentacaoRepositorio>();
        }

        [Fact]
        public void TestaListarTodasMovimentacoes()
        {
            List<Movimentacao> lista = _repositorio.ListarTodas();

            Assert.NotNull(lista);
            //Assert.Equal(5, lista.Count);
        }

        [Fact]
        public void TestaObterMovimentacaoPorId()
        {
            //Arrange
            //Act
            var movimentacao = _repositorio.ObterPorId(1);

            //Assert
            Assert.NotNull(movimentacao);
        }
        
    }
}