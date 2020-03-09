using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface IAppCliente : IAppGeneric<Cliente>
    {
        void Adicionar(Cliente a_Cliente);
        void Atualizar(Cliente a_Cliente);
        void Excluir(Cliente a_Cliente);
        Cliente ObterPorId(int a_Id);
        List<Cliente> Listar();
    }
}
