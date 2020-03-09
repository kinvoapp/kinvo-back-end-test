using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface IAppProdutoFinanceiro : IAppGeneric<ProdutoFinanceiro>
    {
        void Adicionar(ProdutoFinanceiro Entity);
        void Atualizar(ProdutoFinanceiro Entity);
        void Excluir(ProdutoFinanceiro Entity);
        ProdutoFinanceiro ObterPorId(int Id);
        List<ProdutoFinanceiro> Listar();
    }
}
