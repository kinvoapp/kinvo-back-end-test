using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface IAppAplicacao : IAppGeneric<Aplicacao>
    {
        void Adicionar(Aplicacao a_Cliente);
        void Atualizar(Aplicacao a_Cliente);
        void Excluir(Aplicacao a_Cliente);
        Aplicacao ObterPorId(int a_Id);
        List<Aplicacao> Listar();
    }
}
