using Aliquota.Domain.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using Aliquota.Infrastructure.DBContext;
using Aliquota.Domain.Entities;

namespace Aliquota.Infrastructure
{
    public class AplicacaoRepository : IAplicacaoRepo
    {
        private AliquotaDBContext _dbContext = null;
        public AplicacaoRepository(AliquotaDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Adicionar(Aplicacao entity)
        {
            _dbContext.Aplicacao.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Excluir(Aplicacao entity)
        {
            _dbContext.Aplicacao.Remove(entity);
            _dbContext.SaveChanges();
        }

        public Aplicacao ObterPorId(int Id)
        {
            return (Aplicacao)_dbContext.Aplicacao.Find(Id);
        }

        public IList<Aplicacao> Listar(Predicate<Aplicacao> queryPredicate = null)
        {
            return _dbContext.Aplicacao.Where(x => queryPredicate(x)).ToList();
        }

        public void Atualizar(Aplicacao entity)
        {
            _dbContext.Aplicacao.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
