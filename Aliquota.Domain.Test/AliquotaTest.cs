using System;
using Xunit;
using Aliquota.Domain;
using Aliquota.Domain.Services;
using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Test
{
    public class AliquotaTest
    {
        readonly AliquotaService _aliquotaService;
        readonly Cliente _cliente;
        readonly Produto _produto;
        public AliquotaTest()
        {
            _aliquotaService = new AliquotaService();
            _cliente = AliquotaService.Clientefactory();
            _produto = AliquotaService.Produtofactory();
        }

        [Fact]
        public void AplicacaoZeroTest()
        {
            var aplicacao = _aliquotaService.DoAplicar(_produto, _cliente, DateTime.Today, decimal.Zero);
            bool isAplicado = aplicacao != null && aplicacao.ValorAplicado == decimal.Zero;
            Assert.False(isAplicado, "Aplicação com valor menor ou igual a zero");
        }

        [Fact]
        public void AplicacaoMaiorZeroTest()
        {
            var aplicacao = _aliquotaService.DoAplicar(_produto, _cliente, DateTime.Today, 1000);
            bool isAplicado = aplicacao != null && aplicacao.ValorAplicado > decimal.Zero;
            Assert.True(isAplicado, "Valor maior que zero não aplicado");
        }

        [Fact]
        public void ResgateCalculaIRTest()
        {
            var aplicacao = _aliquotaService.DoAplicar(_produto, _cliente, DateTime.Today, 1000);
            aplicacao.Rendimento = 20m;
            _aliquotaService.DoResgatar(aplicacao, DateTime.Today.AddDays(+5));
            Assert.True(aplicacao.IR > decimal.Zero, "Resgate não pode acontecer quando data de resgate é menor que a aplicação");
        }

        [Fact]
        public void ResgateIR_22_5_Test()
        {
            var aplicacao = _aliquotaService.DoAplicar(_produto, _cliente, DateTime.Today, 1000);
            aplicacao.Rendimento = 20m;
            _aliquotaService.DoResgatar(aplicacao, DateTime.Today.AddDays(5));
            Assert.Equal(4.5m, aplicacao.IR, 2);
        }

        [Fact]
        public void ResgateIR_18_5_Test()
        {
            var aplicacao = _aliquotaService.DoAplicar(_produto, _cliente, DateTime.Today, 1000);
            aplicacao.Rendimento = 20m;
            _aliquotaService.DoResgatar(aplicacao, DateTime.Today.AddMonths(14));
            Assert.Equal(3.7m, aplicacao.IR, 2);
        }

        [Fact]
        public void ResgateIR_15_Test()
        {
            var aplicacao = _aliquotaService.DoAplicar(_produto, _cliente, DateTime.Today, 1000);
            aplicacao.Rendimento = 20m;
            _aliquotaService.DoResgatar(aplicacao, DateTime.Today.AddMonths(30));
            Assert.Equal(3m, aplicacao.IR, 2);
        }

        [Fact]
        public void ResgateDataMenorTest()
        {
            var aplicacao = _aliquotaService.DoAplicar(_produto, _cliente, DateTime.Today, 1000);
            _aliquotaService.DoResgatar(aplicacao, DateTime.Today.AddDays(-1));
            Assert.False(aplicacao.IsResgado, "Resgate não pode acontecer quando data de resgate é menor que a aplicação");
        }
    }
}
