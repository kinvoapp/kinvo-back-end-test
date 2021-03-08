using Aliquota.Domain.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using Aliquota.Infrastructure.DBContext;
using Aliquota.Domain.Entities;
using System.Threading.Tasks;

namespace Aliquota.Infrastructure
{
    public class ClienteRepository : IClienteRepo
    {
        private AliquotaDBContext _dbContext = null;
        public  ClienteRepository(AliquotaDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Adicionar(Cliente entity)
        {
            await _dbContext.Cliente.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Excluir(Cliente entity)
        {
            _dbContext.Cliente.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Cliente> ObterPorId(int Id)
        {
            return (Cliente) await _dbContext.Cliente.FindAsync(Id);
        }

        public async Task<IList<Cliente>> Listar(Predicate<Cliente> queryPredicate = null)
        {
            return _dbContext.Cliente.Where(x => queryPredicate(x)).ToList();
        }

        public async Task Atualizar(Cliente entity)
        {
            _dbContext.Cliente.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
