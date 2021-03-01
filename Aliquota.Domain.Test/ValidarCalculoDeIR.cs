using Aliquota.Domain.AggregatesModel.ProdutoFinanceiroAggregate;
using Aliquota.Domain.AggregatesModel.Usuario;
using Aliquota.Infrastructure;
using Aliquota.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class ValidarCalculoDeIR
    {
        private ProdutoFinanceiro produtoFinanceiro = new ProdutoFinanceiro("Investimento de teste, rendimento de 10% ao mês", 10);
        private AliquotaContext context = new AliquotaContext(new DbContextOptionsBuilder<AliquotaContext>().UseInMemoryDatabase("DbTeste").Options);
        private Usuario usuario = new Usuario("Lucas Mesquita Nunes");

        //[Theory(DisplayName = "Valor de resgate de aplicação é correto.")]
        //[InlineData(223.52, 100, 300)]
        //[InlineData(274.28, 100, 365)]
        //[InlineData(821.25, 100, 730)]
        //public void ValidarValorDeResgate(double resultadoEsperado, double valorInicialDeAplicacao, int tempoDaAplicacaoEmDias)
        //{
        //    ProdutoFinanceiroRepository produtoFinanceiroRepository = new ProdutoFinanceiroRepository(context);
        //    produtoFinanceiro = produtoFinanceiroRepository.Add(produtoFinanceiro);
        //    context.SaveChanges();

        //    UsuarioRepository usuarioRepository = new UsuarioRepository(context);
        //    usuario = usuarioRepository.Add(usuario);
        //    context.SaveChanges();

        //    //Aplicacao aplicacao = produtoFinanceiro.AddAplicacao(valorInicialDeAplicacao, usuario.Id);
        //    //context.SaveChanges();

        //    ProdutoFinanceiroDomain produtoFinanceiroDomain = new ProdutoFinanceiroDomain(produtoFinanceiro);
        //    double valorResgate = produtoFinanceiroDomain.CalcularValorAResgatar(aplicacao.Id, DateTime.UtcNow.AddDays(tempoDaAplicacaoEmDias));
        //    Assert.Equal(resultadoEsperado, Math.Round(valorResgate, 2));
        //}
    }
}
