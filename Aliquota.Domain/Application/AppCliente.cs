using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class AppCliente : IAppCliente
    {
        IAppCliente i_InterfaceCliente;

        public AppCliente(IAppCliente a_ICliente)
        {
            i_InterfaceCliente = a_ICliente;
        }

        public void Adicionar(Cliente a_Cliente)
        {
            i_InterfaceCliente.Adicionar(a_Cliente);
        }
        public void Atualizar(Cliente a_Cliente)
        {
            i_InterfaceCliente.Atualizar(a_Cliente);
        }
        public void Excluir(Cliente a_Cliente)
        {
            i_InterfaceCliente.Excluir(a_Cliente);
        }
        public Cliente ObterPorId(int a_ClienteID)
        {
            return i_InterfaceCliente.ObterPorId(a_ClienteID);
        }
        public List<Cliente> Listar()
        {
            return i_InterfaceCliente.Listar();
        }
    }
}
