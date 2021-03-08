using Aliquota.Domain.Entities;
using Aliquota.Domain.IRepos;
using System;
using System.Collections.Generic;

namespace Aliquota.Applications
{
    public class AppCliente : IAppCliente
    {
        private IClienteRepo _repo;

        public AppCliente(IClienteRepo clienteRepo)
        {
            _repo = clienteRepo;
        }

        public void Adicionar(Cliente cliente)
        {            
            _repo.Adicionar(cliente);
        }
        public void Atualizar(Cliente cliente)
        {          
            _repo.Atualizar(cliente);
        }
        public void Excluir(Cliente cliente)
        {
            _repo.Excluir(cliente);
        }
        public Cliente ObterPorId(int clienteId)
        {
            return _repo.ObterPorId(clienteId);
        }
        public IList<Cliente> Listar(Predicate<Cliente> queryPredicate = null)
        {
            return _repo.Listar(queryPredicate);
        }        
    }
}
