using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Interfaces
{
    public interface IAplicacao : IGeneric<Aplicacao>
    {
        void Adicionar(Aplicacao Entity);
        void Atualizar(Aplicacao Entity);
        void Excluir(Aplicacao Entity);
        Aplicacao ObterPorId(int Id);
        List<Aplicacao> Listar();
    }
}
