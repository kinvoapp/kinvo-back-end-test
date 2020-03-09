using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Interfaces
{
    public interface IProdutoFinanceiro : IGeneric<ProdutoFinanceiro>
    {
        void Adicionar(ProdutoFinanceiro Entity);
        void Atualizar(ProdutoFinanceiro Entity);
        void Excluir(ProdutoFinanceiro Entity);
        ProdutoFinanceiro ObterPorId(int Id);
        List<ProdutoFinanceiro> Listar();
    }
}
