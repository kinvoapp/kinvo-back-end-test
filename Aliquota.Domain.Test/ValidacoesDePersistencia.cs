using System;
using Xunit;
using Aliquota.Domain.AggregatesModel.ProdutoFinanceiroAggregate;
using Aliquota.Infrastructure.Repositories;
using Aliquota.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Aliquota.Domain.AggregatesModel.Usuario;
using Aliquota.Domain.AggregatesModel.AplicacaoAggregate;

namespace Aliquota.Domain.Test
{
    public class ValidacoesDePersistencia
    {
        private AliquotaContext context = new AliquotaContext(new DbContextOptionsBuilder<AliquotaContext>().UseInMemoryDatabase("DbTeste").Options);

        private ProdutoFinanceiro produtoFinanceiro = new ProdutoFinanceiro("Investimento de teste, rendimento de 10% ao mês", 10);
        private Usuario usuario = new Usuario("Lucas Mesquita Nunes");

        //Verifica se a Entidade de ProdutoFinanceiro está realmente sendo persistida.
        [Fact(DisplayName = "Persistencia de ProdutoFinanceiro está correta.")]
        public void ValidarPersistenciaProdutoFinanceiro()
        {
            ProdutoFinanceiroRepository produtoFinanceiroRepository = new ProdutoFinanceiroRepository(context);
            produtoFinanceiro = produtoFinanceiroRepository.Add(produtoFinanceiro);
            context.SaveChanges();

            ProdutoFinanceiroRepository segundoProdutoFinanceiroRepository = new ProdutoFinanceiroRepository(context);
            ProdutoFinanceiro segundoProdutoFinanceiro = segundoProdutoFinanceiroRepository.GetProdutoFinanceiroById(produtoFinanceiro.Id);

            Assert.Equal(segundoProdutoFinanceiro, produtoFinanceiro);
        }

        //Verifica se a Entidade de ProdutoFinanceiro está realmente sendo persistida.
        [Fact(DisplayName = "Persistencia de Aplicacao está correta.")]
        public void ValidarPersistenciaAplicacao()
        {
            ProdutoFinanceiroRepository produtoFinanceiroRepository = new ProdutoFinanceiroRepository(context);
            produtoFinanceiro = produtoFinanceiroRepository.Add(produtoFinanceiro);
            context.SaveChanges();

            UsuarioRepository usuarioRepository = new UsuarioRepository(context);
            usuario = usuarioRepository.Add(usuario);

            Aplicacao aplicacao = new Aplicacao(100, produtoFinanceiro.Id, usuario.Id);
            AplicacaoRepository aplicacaoRepository = new AplicacaoRepository(context);
            aplicacao = aplicacaoRepository.Add(aplicacao);
            context.SaveChanges();

            AplicacaoRepository segundoAplicacaoRepository = new AplicacaoRepository(context);
            Aplicacao segundaAplicacao = segundoAplicacaoRepository.GetAplicacaoById(aplicacao.Id);
            Assert.Equal(aplicacao, segundaAplicacao);
        }

        [Fact(DisplayName ="Persistencia de Usuario está correta.")]
        public void ValidarUsuario()
        {
            UsuarioRepository usuarioRepository = new UsuarioRepository(context);
            usuario = usuarioRepository.Add(usuario);
            context.SaveChanges();

            UsuarioRepository segundoUsuarioRepository = new UsuarioRepository(context);
            Usuario segundoUsuario = segundoUsuarioRepository.GetUsuarioById(usuario.Id);

            Assert.Equal(usuario, segundoUsuario);
        }
    }
}
