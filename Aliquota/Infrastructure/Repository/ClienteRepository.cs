using Aliquota.Domain.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using Aliquota.Infrastructure.DBContext;
using Aliquota.Domain.Entities;

namespace Aliquota.Infrastructure
{
    public class ClienteRepository : IClienteRepo
    {
        private AliquotaDBContext _dbContext = null;
        public ClienteRepository(AliquotaDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Adicionar(Cliente entity)
        {
            _dbContext.Cliente.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Excluir(Cliente entity)
        {
            _dbContext.Cliente.Remove(entity);
            _dbContext.SaveChanges();
        }

        public Cliente ObterPorId(int Id)
        {
            return (Cliente)_dbContext.Cliente.Find(Id);
        }

        public IList<Cliente> Listar(Predicate<Cliente> queryPredicate = null)
        {
            return _dbContext.Cliente.Where(x => queryPredicate(x)).ToList();
        }

        public void Atualizar(Cliente entity)
        {
            _dbContext.Cliente.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
