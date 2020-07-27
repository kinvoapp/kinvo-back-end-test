using Aliquota.Domain.Entities;
using Aliquota.Domain.Repository;
using Aliquota.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Aliquota.Repository.Repositories
{
    public class AplicacaoRepository: IAplicacaoRepository
    {
        protected readonly InvestimentoDbContext Db;
        protected readonly DbSet<Aplicacao> DbSet;

        public AplicacaoRepository(InvestimentoDbContext context)
        {
            Db = context;
            DbSet = Db.Set<Aplicacao>();
        }

        public Aplicacao ObterPorId(Guid id)
        {
            return DbSet.Include(x => x.Resgate).FirstOrDefault(x => x.Id == id);
        }


        public IEnumerable<Aplicacao> ObterTodos()
        {
            return DbSet.Include(x => x.Resgate);
        }

        public IEnumerable<Aplicacao> ObterTodos(Expression<Func<Aplicacao, bool>> filtro)
        {
            return DbSet.Where(filtro).Include(x => x.Resgate);
        }

        public Aplicacao Inserir(Aplicacao aplicacao)
        {
            DbSet.Add(aplicacao);
            Db.SaveChanges();

            return aplicacao;
        }

        public Aplicacao Atualizar(Aplicacao aplicacao)
        {
            DbSet.Update(aplicacao);
            Db.SaveChanges();

            return aplicacao;
        }
    }
}
