// ===================================================================
//  Empresa: 
//  Projeto: 
//  Autores: Valnei Filho
//  E-mail: v_marinpietri@yahoo.com.br
//  Data Criação: 04/03/2020
// ===================================================================


#region

using System;
using System.Collections.Generic;
using System.Data;
using Aliquota.App;
using Aliquota.App.Interfaces;
using Aliquota.Domain;
using Xunit;

#endregion

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact(DisplayName = "Cliente realiza aplicação financeira com sucesso usando polimorfismo")]
        public void ClienteRealizaAplicacaoFinanceiraComSucesso1()
        {
            //A intenção aqui é usar a técnica de polimorfismo

            ClienteServiceTemplate clienteService;
            var cliente = new Cliente { Nome = "Valnei Filho" };
            InformacaoFiscal  informacaoFiscal;
            //Calculo para um funcionario da intituiçao financeira
            clienteService = new FuncionarioService(cliente);

            var produtoA = new Produto { Data = new DateTime(2019, 1, 1), Nome = "CDB", PercentualRedimento = 2, Saldo = 1000 };
            var produtos = new List<Produto>();
            produtos.Add(produtoA);//Vários produtos podem ser comercializados
            clienteService.Aplicar(produtos);
            informacaoFiscal = clienteService.Resgatar(500, 1, DateTime.Now.Date);
            Assert.Equal(22.5m, informacaoFiscal.Aliquota);
            Assert.Equal(10, informacaoFiscal.RedimentoAplicacao);
            Assert.Equal(2.25m, informacaoFiscal.ValorRetido);
            Assert.Equal(517.75m, informacaoFiscal.Produto.Saldo);

            //===================================================================
            //Calculo para um cliente especial
            clienteService = new ClienteEspecialService(cliente);
            var produtoB = new Produto { Data = new DateTime(2019, 1, 1), Nome = "CDB", PercentualRedimento = 2, Saldo = 1000 };
            var produtosB = new List<Produto>();
            produtosB.Add(produtoB);
            clienteService.Aplicar(produtosB);
            informacaoFiscal = clienteService.Resgatar(500, 1, DateTime.Now.Date);
            Assert.Equal(22.5m, informacaoFiscal.Aliquota);
            Assert.Equal(10, informacaoFiscal.RedimentoAplicacao);
            Assert.Equal(2.25m, informacaoFiscal.ValorRetido);
            Assert.Equal(517.75m, informacaoFiscal.Produto.Saldo); 


        }


        [Fact(DisplayName = "Até 1 ano de aplicação: 22,5% sobre o lucro")]
        public void ClienteRealizaAplicacaoFinanceiraNaFaixa225ComSucesso()
        {
            //A intenção aqui é usar a técnica de polimorfismo

            ClienteServiceTemplate clienteService;
            var cliente = new Cliente { Nome = "Valnei Filho" };
            InformacaoFiscal informacaoFiscal;
            //Calculo para um funcionario da intituiçao financeira
            clienteService = new ClienteEspecialService(cliente);

            var produtoA = new Produto { Data = new DateTime(2019, 1, 1), Nome = "CDB", PercentualRedimento = 2, Saldo = 1000 };
            var produtos = new List<Produto>();
            produtos.Add(produtoA);//Vários produtos podem ser comercializados
            clienteService.Aplicar(produtos);
            informacaoFiscal = clienteService.Resgatar(500, 1, DateTime.Now.Date);
            Assert.Equal(22.5m, informacaoFiscal.Aliquota);
            Assert.Equal(10, informacaoFiscal.RedimentoAplicacao);
            Assert.Equal(2.25m, informacaoFiscal.ValorRetido);
            Assert.Equal(517.75m, informacaoFiscal.Produto.Saldo); 
        }


        [Fact(DisplayName = "Cliente realiza aplicação financeira com sucesso")]
        public void ClienteRealizaAplicacaoFinanceiraComSucesso()
        {
            var cliente = new Cliente {Nome = "Valnei Filho"};
            var clienteService = new ClienteEspecialService(cliente);
            var produtoA = new Produto {Data = new DateTime(2019, 1, 1), Nome = "CDB", PercentualRedimento = 2, Saldo = 1000};
            var produtos = new List<Produto>();
            produtos.Add(produtoA);
            clienteService.Aplicar(produtos);
            var informacaoFiscal  = clienteService.Resgatar(500, 1, DateTime.Now.Date); 
            Assert.Equal(22.5m, informacaoFiscal.Aliquota);
            Assert.Equal(10, informacaoFiscal.RedimentoAplicacao);
            Assert.Equal(2.25m, informacaoFiscal.ValorRetido);
            Assert.Equal(517.75m, informacaoFiscal.Produto.Saldo);
        }


        [Fact(DisplayName = "Cliente realiza aplicação financeira sem saldo inicial")]
        public void ClienteRealizaAplicacaoFinanceiraSemSaldoInicial()
        {
            var cliente = new Cliente {Nome = "Valnei Filho"};
            var clienteService = new ClienteComumService(cliente);
            var produtoA = new Produto {Data = new DateTime(2019, 1, 1), Nome = "CDB", PercentualRedimento = 2, Saldo = 0};
            var produtos = new List<Produto>();
            produtos.Add(produtoA);

            void UnitTest()
            {
                clienteService.Aplicar(produtos);
            }

            var ex = Record.Exception((Action) UnitTest);
            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);
        }

        
        [Theory(DisplayName = "Cliente realiza resgate sem saldo")]
        [InlineData(1000, 1200)]
        public void ClienteRealizaResgateSemSaldo(decimal saldo,decimal valorResgate)
        {
            var cliente = new Cliente { Nome = "Valnei Filho" };
            var clienteService = new ClienteComumService(cliente);
            var produtoA = new Produto { Data = new DateTime(2019, 1, 1), Nome = "CDB", PercentualRedimento = 2, Saldo = saldo };
            var produtos = new List<Produto>();
            produtos.Add(produtoA);

            clienteService.Aplicar(produtos);
          

            void UnitTest(){

                clienteService.Resgatar(valorResgate, 1, DateTime.Now.Date);
            }

            var ex = Record.Exception((Action)UnitTest);
            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);
           
        }

        [Fact(DisplayName = "A data de resgate não pode ser menor que a data de aplicação")] 
        public void ClienteNaoRealizaResgateEmFuncaoDataResgateMenoDataAplicacao()
        {
           
                var cliente = new Cliente { Nome = "Valnei Filho" };
                var clienteService = new ClienteEspecialService(cliente);
                var produtoA = new Produto { Data = new DateTime(2019, 12, 1), Nome = "CDB", PercentualRedimento = 2, Saldo = 1000 };
                var produtos = new List<Produto>();
                produtos.Add(produtoA);

                clienteService.Aplicar(produtos);


                  void UnitTest()
                  {

                             clienteService.Resgatar(500, 1, new DateTime(2019, 11, 1));

                  } 

                 var ex = Record.Exception((Action)UnitTest);
                  Assert.NotNull(ex);
                 Assert.IsType<InvalidOperationException>(ex);
             

        }

        [Fact(DisplayName = "De 1 a 2 anos de aplicação: 18,5% sobre o lucro")]
        public void ClienteRealizaAplicacaoFinanceiraNaFaixa2ComSucesso()
        {

            var cliente = new Cliente { Nome = "Valnei Filho" };
            var clienteService = new ClienteComumService(cliente);
            var produtoA = new Produto { Data = new DateTime(2018, 1, 1), Nome = "CDB", PercentualRedimento = 2, Saldo = 1000 };
            var produtos = new List<Produto>();
            produtos.Add(produtoA);
            clienteService.Aplicar(produtos);
            var informacaoFiscal =  clienteService.Resgatar(500, 1, DateTime.Now.Date);
            
            Assert.Equal(18.5m, informacaoFiscal.Aliquota);
            Assert.Equal(20, informacaoFiscal.RedimentoAplicacao);
            Assert.Equal(3.70m, informacaoFiscal.ValorRetido);
            Assert.Equal(536.30m, informacaoFiscal.Produto.Saldo);


        }

        [Fact(DisplayName = "Acima de 2 anos de aplicação: 15% sobre o lucro")]
        public void ClienteRealizaAplicacaoFinanceiraNaFaixa3ComSucesso()
        {

            var cliente = new Cliente { Nome = "Valnei Filho" };
            var clienteService = new ClienteComumService(cliente);
            var produtoA = new Produto { Data = new DateTime(2018, 1, 1), Nome = "CDB", PercentualRedimento = 2, Saldo = 1000 };
            var produtos = new List<Produto>();
            produtos.Add(produtoA);
            clienteService.Aplicar(produtos);
            var informacaoFiscal =  clienteService.Resgatar(500, 1, DateTime.Now.Date.AddYears(2));
           

            Assert.Equal(15m, informacaoFiscal.Aliquota);
            //4 anos de aplicação
            Assert.Equal(40, informacaoFiscal.RedimentoAplicacao);
            Assert.Equal(6m, informacaoFiscal.ValorRetido);
            Assert.Equal( 574m, informacaoFiscal.Produto.Saldo);


        }



    }
}