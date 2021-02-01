using NUnit.Framework;
using System;

namespace Aliquota.Domain.Test
{
    public class UnitTestAplicacao
    {
        public readonly decimal IR_FAIXA1 = Convert.ToDecimal(0.225);
        public readonly decimal IR_FAIXA2 = Convert.ToDecimal(0.185);
        public readonly decimal IR_FAIXA3 = Convert.ToDecimal(0.15);

        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void CalculoIRFaixa1_DeveRetornaOK()
        {
            Models.Aplicacao aplicacao = new Models.Aplicacao();
            aplicacao.Nome = "Aplicacao 1";
            aplicacao.ValorAplicado = 10;
            aplicacao.ValorAplicado = 100;
            aplicacao.DataAplicacao = DateTime.Now;
            aplicacao.DataRetirada = DateTime.Now.AddDays(40);

            Assert.AreEqual(aplicacao.AliquotaIR, IR_FAIXA1);
        }

        [Test]
        public void CalculoIRFaixa2_DeveRetornaOK()
        {
            Models.Aplicacao aplicacao = new Models.Aplicacao();
            aplicacao.Nome = "Aplicacao 1";
            aplicacao.ValorAplicado = 10;
            aplicacao.ValorAplicado = 100;
            aplicacao.DataAplicacao = DateTime.Now;
            aplicacao.DataRetirada = DateTime.Now.AddDays(400);

            Assert.AreEqual(aplicacao.AliquotaIR, IR_FAIXA2);
        }

        [Test]
        public void CalculoIRFaixa3_DeveRetornaOK()
        {
            Models.Aplicacao aplicacao = new Models.Aplicacao();
            aplicacao.Nome = "Aplicacao 1";
            aplicacao.ValorAplicado = 10;
            aplicacao.ValorAplicado = 100;
            aplicacao.DataAplicacao = DateTime.Now;
            aplicacao.DataRetirada = DateTime.Now.AddDays(800);

            Assert.AreEqual(aplicacao.AliquotaIR, IR_FAIXA3);
        }
        
        [Test]
        public void CalculoIRFaixa1Erro_DeveRetornaOK()
        {
            Models.Aplicacao aplicacao = new Models.Aplicacao();
            aplicacao.Nome = "Aplicacao 1";
            aplicacao.ValorAplicado = 10;
            aplicacao.ValorAplicado = 100;
            aplicacao.DataAplicacao = DateTime.Now;
            aplicacao.DataRetirada = DateTime.Now.AddDays(700);

            Assert.AreNotEqual(aplicacao.AliquotaIR, IR_FAIXA1);
        }
    }
}