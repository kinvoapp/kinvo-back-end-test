using System;
using Xunit;
using Aliquota.Domain.AggregatesModel.ProdutoFinanceiroAggregate;
using Aliquota.Infrastructure.Repositories;
using Aliquota.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Aliquota.Domain.AggregatesModel.Usuario;

namespace Aliquota.Domain.Test
{
    public class ValidacoesDePersistencia
    {
        private ProdutoFinanceiro produtoFinanceiro = new ProdutoFinanceiro("Investimento de teste, rendimento de 10% ao mês", 10);
        private AliquotaContext context = new AliquotaContext(new DbContextOptionsBuilder<AliquotaContext>().UseInMemoryDatabase("DbTeste").Options);
        private Usuario usuario = new Usuario("Lucas Mesquita Nunes");
             
        [Fact]
        public void ValidarPersistenciaProdutoFinanceiro()
        {
            ProdutoFinanceiroRepository produtoFinanceiroRepository = new ProdutoFinanceiroRepository(context);
            produtoFinanceiro = produtoFinanceiroRepository.Add(produtoFinanceiro);
            context.SaveChanges();

            ProdutoFinanceiro mProdutoFinanceiro = produtoFinanceiroRepository.GetProdutoFinanceiroById(produtoFinanceiro.Id);

            Assert.Equal(mProdutoFinanceiro.Id, produtoFinanceiro.Id);
        }

        //[Fact]
        //public void ValidarPersistenciaAplicacao()
        //{
        //    ProdutoFinanceiroRepository produtoFinanceiroRepository = new ProdutoFinanceiroRepository(context);
        //    produtoFinanceiro = produtoFinanceiroRepository.Add(produtoFinanceiro);
        //    context.SaveChanges();

        //    UsuarioRepository usuarioRepository = new UsuarioRepository(context);
        //    usuario = usuarioRepository.Add(usuario);
        //    context.SaveChanges();

        //    //produtoFinanceiro.AddAplicacao(100, usuario.Id);
        //    context.SaveChanges();

        //    ProdutoFinanceiro mProdutoFinanceiro = produtoFinanceiroRepository.GetProdutoFinanceiroById(produtoFinanceiro.Id);

        //    Assert.Equal(1, mProdutoFinanceiro.Aplicacoes.Count);
        //}
    }
}
