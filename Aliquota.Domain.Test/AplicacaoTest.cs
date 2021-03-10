using Aliquota.Applications;
using Aliquota.Domain.Entities;
using Aliquota.Domain.IRepos;
using Aliquota.Infrastructure;
using Aliquota.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class AplicacaoTest : IClassFixture<ServicesFixture>
    {
        private ServiceProvider _serviceProvider;
        private readonly IAppAplicacao _appAplicacao;
        public AplicacaoTest(ServicesFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
            _appAplicacao = _serviceProvider.GetService<IAppAplicacao>();
        }

        [Fact]
        public void Aplicacao_Valor0_Invalida()
        {
            Aplicacao aplicacao = new Aplicacao();
            aplicacao.Valor = 0;

            bool aplicacaoValida = true;
            try
            {
                _appAplicacao.ValidarAplicacao(aplicacao);
            }
            //Implementar e tratar aplicação tipada de validação de Aplicação
            catch (Exception)
            {
                aplicacaoValida = false;
            }
            finally
            {
                Assert.False(aplicacaoValida, "ValidarAplicacao - Aplicação com valor = 0 não deve ser válida");
            }
        }

        [Fact]
        public void Aplicacao_ValorMaiorQue0_Valido()
        {
            Aplicacao aplicacao = new Aplicacao();
            aplicacao.Valor = 10;

            bool aplicacaoValida = true;
            try
            {
                _appAplicacao.ValidarAplicacao(aplicacao);
            }
            //Implementar e tratar aplicação tipada de validação de Aplicação
            catch (Exception)
            {
                aplicacaoValida = false;
            }
            finally
            {
                Assert.True(aplicacaoValida, "ValidarAplicacao - Aplicação com valor maior que 0 deve ser válida");
            }
        }

        [Fact]
        public void Aplicacao_DataRetiradaMenorDataAplicacao_Invalida()
        {
            Aplicacao aplicacao = new Aplicacao();
            aplicacao.Valor = 10;
            DateTime l_DateTimeNow = DateTime.Now;
            aplicacao.DataAplicacao = l_DateTimeNow.AddMonths(2);
            aplicacao.DataRetirada = l_DateTimeNow;

            bool aplicacaoValida = true;
            try
            {
                _appAplicacao.ValidarAplicacao(aplicacao);
            }
            //Implementar e tratar aplicação tipada de validação de Aplicação
            catch (Exception)
            {
                aplicacaoValida = false;
            }
            finally
            {
                Assert.False(aplicacaoValida, "ValidarAplicacao - Aplicação com data de aplicação maior que data de retirada deve ser inválida");
            }
        }

        [Fact]
        public void Aplicacao_DataRetiradaMaiorDataAplicacao_Valida()
        {
            Aplicacao aplicacao = new Aplicacao();
            aplicacao.Valor = 10;
            DateTime l_DateTimeNow = DateTime.Now;
            aplicacao.DataAplicacao = l_DateTimeNow;
            aplicacao.DataRetirada = l_DateTimeNow.AddMonths(2);
            bool aplicacaoValida = true;
            try
            {
                _appAplicacao.ValidarAplicacao(aplicacao);
            }
            //Implementar e tratar aplicação tipada de validação de Aplicação
            catch (Exception)
            {
                aplicacaoValida = false;
            }
            finally
            {
                Assert.True(aplicacaoValida, "ValidarAplicacao - Aplicação com Data Retirada > Data Aplicação é válida");
            }
        }

        [Fact]
        public void Aplicacao_PercentualIRDevidoDeveSer22_5()
        {                        
            decimal l_Resultado = _appAplicacao.ObterPercentualIR(12);

            Assert.Equal(l_Resultado, (decimal)0.225, 3);
        }

        [Fact]
        public void Aplicacao_PercentualIRDevidoDeveSer18_5()
        {
            decimal l_Resultado = _appAplicacao.ObterPercentualIR(16);

            Assert.Equal(l_Resultado, (decimal)0.185, 3);
        }

        [Fact]
        public void Aplicacao_PercentualIRDevidoDeveSer15()
        {
            decimal l_Resultado = _appAplicacao.ObterPercentualIR(32);

            Assert.Equal(l_Resultado, (decimal)0.15, 3);
        }        

        //[Fact]
        //public void Aplicacao_IRDevidoDeveSer15()
        //{
        //    decimal l_Resultado = AppAplicacao.ObterPercentualIR(32);

        //    Assert.Equal(l_Resultado, (decimal)1.15, 2);
        //}
    }

    public class ServicesFixture
    {
        public ServicesFixture()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection
                .AddDbContext<AliquotaDBContext>(x => x.UseSqlServer("Server=DESKTOP-NUDD5V5\\MSSQLSERVER01;Database=Kinvo;User Id=sa;Password=sa;"),
                    ServiceLifetime.Transient);
            serviceCollection.AddScoped<IAppAplicacao, AppAplicacao>();
            serviceCollection.AddScoped<IAplicacaoRepo, AplicacaoRepository>();
            serviceCollection.AddScoped<AliquotaDBContext>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }
}
