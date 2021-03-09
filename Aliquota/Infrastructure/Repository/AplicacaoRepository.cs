using Aliquota.Domain.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using Aliquota.Infrastructure.DBContext;
using Aliquota.Domain.Entities;
using System.Threading.Tasks;

namespace Aliquota.Infrastructure
{
    public class AplicacaoRepository : IAplicacaoRepo
    {
        private AliquotaDBContext _dbContext = null;
        public AplicacaoRepository(AliquotaDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Adicionar(Aplicacao entity)
        {
            await _dbContext.Aplicacao.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Excluir(Aplicacao entity)
        {
            _dbContext.Aplicacao.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Aplicacao> ObterPorId(int Id)
        {
            return await _dbContext.Aplicacao.FindAsync(Id);
        }

        public async Task<IList<Aplicacao>> Listar(Predicate<Aplicacao> queryPredicate = null)
        {
            if (queryPredicate == null)
                return _dbContext.Aplicacao.ToList();
            return _dbContext.Aplicacao.Where(x => queryPredicate(x)).ToList();
        }

        public async Task Atualizar(Aplicacao entity)
        {
            _dbContext.Aplicacao.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
