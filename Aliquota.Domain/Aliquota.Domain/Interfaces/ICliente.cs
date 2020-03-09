using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Interfaces
{
    interface ICliente : IGeneric<Cliente>
    {
        void Adicionar(Cliente Entity);
        void Atualizar(Cliente Entity);
        void Excluir(Cliente Entity);
        Cliente ObterPorId(int Id);
        List<Cliente> Listar();
    }
}
