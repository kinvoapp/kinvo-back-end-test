using AliquotaImpostoRenda.Aplicacao;
using AliquotaImpostoRenda.Dados.Interface;
using AliquotaImpostoRenda.Dominio.DTO;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AliquotaImpostoRenda.Teste.Repositorios
{
    public class ClienteAplicacaoTeste
    {
        private readonly Mock<IClienteRepositorio> _repositorioMock;

        public ClienteAplicacaoTeste()
        {
            _repositorioMock = new Mock<IClienteRepositorio>();
        }

        private void configurarBuscarCliente()
        {
            _repositorioMock.Setup(r => r.BuscarCliente("Teste")).Returns(new ClienteDTO { Id = 1, Nome = "Teste" });
        }

        private void configurarListarCliente()
        {
            _repositorioMock.Setup(r => r.ListarTodos()).Returns(new List<ClienteDTO> { new ClienteDTO { Id = 1, Nome = "Teste" }, new ClienteDTO { Id = 2, Nome = "Teste 2" } });
        }

        private void configurarListarClienteNenhum()
        {
            _repositorioMock.Setup(r => r.ListarTodos()).Returns(new List<ClienteDTO>());
        }

        private ClienteAplicacao InstanciaClienteAplicacao()
        {
            return new ClienteAplicacao(_repositorioMock.Object);
        }

        [Fact]
        public void VerificarBuscarClienteNome()
        {
            configurarBuscarCliente();
            var clienteAplicacao = InstanciaClienteAplicacao();
            var resultado = clienteAplicacao.BuscarCliente("Teste");
            Assert.Equal("Teste", resultado.Nome);
        }

        [Fact]
        public void VerificarBuscarClienteNaoNulo()
        {
            configurarBuscarCliente();
            var clienteAplicacao = InstanciaClienteAplicacao();
            var resultado = clienteAplicacao.BuscarCliente("Teste");
            Assert.NotNull(resultado);
        }

        [Fact]
        public void VerificarBuscarClienteEstejaNulo()
        {
            configurarBuscarCliente();
            var clienteAplicacao = InstanciaClienteAplicacao();
            var resultado = clienteAplicacao.BuscarCliente("Teste 2");
            Assert.Null(resultado);
        }

        [Fact]
        public void VerificarListarClientesQuantidadeRegistro()
        {
            configurarListarCliente();
            var clienteAplicacao = InstanciaClienteAplicacao();
            var resultado = clienteAplicacao.ListarClientes().Result;
            Assert.Equal(2, resultado.Count());
        }

        [Fact]
        public void VerificarListarClientesNulo()
        {
            configurarListarClienteNenhum();
            var clienteAplicacao = InstanciaClienteAplicacao();
            var resultado = clienteAplicacao.ListarClientes().Result;
            Assert.NotNull(resultado);
        }

        [Fact]
        public void VerificarListarClientesVerificarRegistro()
        {
            configurarListarCliente();
            var clienteAplicacao = InstanciaClienteAplicacao();
            var resultado = clienteAplicacao.ListarClientes().Result;
            Assert.Equal("Teste", resultado[0].Nome);
        }
    }
}
