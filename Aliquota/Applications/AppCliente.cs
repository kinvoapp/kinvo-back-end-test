using Aliquota.Domain.Entities;
using Aliquota.Domain.IRepos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Applications
{
    public class AppCliente : IAppCliente
    {
        private IClienteRepo _repo;

        public AppCliente(IClienteRepo clienteRepo)
        {
            _repo = clienteRepo;
        }

        public async Task Adicionar(Cliente cliente)
        {            
            await _repo.Adicionar(cliente);
        }
        public async Task Atualizar(Cliente cliente)
        {          
            await _repo.Atualizar(cliente);
        }
        public async Task Excluir(Cliente cliente)
        {
            await _repo.Excluir(cliente);
        }
        public async Task<Cliente> ObterPorId(int clienteId)
        {
            return await _repo.ObterPorId(clienteId);
        }
        public async Task<IList<Cliente>> Listar(Predicate<Cliente> queryPredicate = null)
        {
            return await _repo.Listar(queryPredicate);
        }        
    }
}
