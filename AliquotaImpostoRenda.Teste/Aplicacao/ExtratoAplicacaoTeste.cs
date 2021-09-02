using AliquotaImpostoRenda.Aplicacao;
using AliquotaImpostoRenda.Aplicacao.Interface;
using AliquotaImpostoRenda.Dados.Interface;
using AliquotaImpostoRenda.Dominio;
using AliquotaImpostoRenda.Dominio.DTO;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AliquotaImpostoRenda.Teste.Aplicacao
{
    public class ExtratoAplicacaoTeste
    {
        private readonly Mock<IExtratoRepositorio> _repositorioMock;
        private readonly Mock<IClienteAplicacao> _clienteAplicacaoMock;

        public ExtratoAplicacaoTeste()
        {
            _repositorioMock = new Mock<IExtratoRepositorio>();
            _clienteAplicacaoMock = new Mock<IClienteAplicacao>();
        }

        private void MockListarExtratos()
        {
            _repositorioMock.Setup(r => r.ListarExtrato()).Returns(new List<ExtratoDTO> {
                    ConstrucaoClasseBase(new DateTime(2021, 01, 01), new DateTime(2021, 05, 01), 22.5),
                    ConstrucaoClasseBase(new DateTime(2020, 01, 01), new DateTime(2021, 05, 01), 18.5) 
                } 
            );
        }

        private ExtratoAplicacao InstanciaExtratoAplicacao()
        {
            return new ExtratoAplicacao(_repositorioMock.Object, _clienteAplicacaoMock.Object);
        }

        private ExtratoDTO ConstrucaoClasseBase(DateTime dataAplicacao, DateTime dataResgate, double porcentagemPagamento)
        {
            return new ExtratoDTO
            {
                Cliente = new ClienteDTO
                {
                    Id = 1,
                    Nome = "Teste"
                },
                Createad = DateTime.Now,
                DataAplicacao = dataAplicacao,
                DataResgate = dataResgate,
                ClienteId = 1,
                PorcentagemLucro = 5,
                PorcentagemPagamento = porcentagemPagamento,
                TipoEntradaLucro = Dominio.Enum.eTipoEntradaLucro.Porcentagem,
                ValorResgatado = 1500,
                ValorParaPagarImposto = 0
            };
        }

        [Fact]
        public void VerificarCalcularValorParaPagar()
        {
            var classDTO = ConstrucaoClasseBase(new DateTime(2021, 01, 01), new DateTime(2021, 05, 01), 22.5);
            var extratoAplicacao = InstanciaExtratoAplicacao();
            var resultado = extratoAplicacao.CalcularValorParaPagar(classDTO);
            Assert.Equal(16.875, resultado);
        }

        [Theory]
        [InlineData(0.6, 22.5)]
        [InlineData(1.6, 18.5)]
        [InlineData(3, 15)]
        [InlineData(2, 18.5)]
        [InlineData(2.1, 15)]
        public void VerificarVerificarPorcentagem(double TempoAplicacao, double expectativa)
        {
            var extratoAplicacao = InstanciaExtratoAplicacao();
            var resultado = extratoAplicacao.VerificarPorcentagem(TempoAplicacao);
            Assert.Equal(expectativa, resultado);
        }

        [Fact]
        public void VerificarDiferencaData()
        {
            var extratoAplicacao = InstanciaExtratoAplicacao();
            var resultado = extratoAplicacao.DiferencaData(new DateTime(2021, 01, 01), new DateTime(2021, 05, 01));
            Assert.Equal(0.3, resultado);
        }

        [Fact]
        public void VerificarListarExtratosQuantidadeRegistro()
        {
            MockListarExtratos();
            var extratoAplicacao = InstanciaExtratoAplicacao();
            var resultado = extratoAplicacao.ListarExtratos().Result;
            Assert.Equal(2, resultado.Count);
        }

        [Fact]
        public void VerificarListarExtratosInformacao()
        {
            MockListarExtratos();
            var extratoAplicacao = InstanciaExtratoAplicacao();
            var resultado = extratoAplicacao.ListarExtratos().Result;
            Assert.Equal(22.5, resultado[0].PorcentagemPagamento);
        }
    }
}
