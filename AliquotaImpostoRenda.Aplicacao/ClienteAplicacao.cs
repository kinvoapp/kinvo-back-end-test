using AliquotaImpostoRenda.Aplicacao.Interface;
using AliquotaImpostoRenda.Dados.Interface;
using AliquotaImpostoRenda.Dominio.DTO;
using AliquotaImpostoRenda.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AliquotaImpostoRenda.Aplicacao
{
    public class ClienteAplicacao: IClienteAplicacao
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteAplicacao(IClienteRepositorio clienteRepositorio){
            _clienteRepositorio = clienteRepositorio;
        }

        public async Task<List<ClienteDTO>> ListarClientes() =>_clienteRepositorio.ListarTodos();

        public ClienteDTO BuscarCliente(string nome)
        {
            return _clienteRepositorio.BuscarCliente(nome);
        }

        public int GravarCliente(string nome)
        {            
            try
            {
                return _clienteRepositorio.Salvar(new Cliente{ Nome = nome });    
            }
            catch (Exception ex)
            {
                throw ex;
            }   
        }
    }
}
