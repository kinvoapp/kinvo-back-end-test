using Aliquota.Domain.Entities;
using Aliquota.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class AppProdutoFinanceiro : IAppProdutoFinanceiro
    {
        IProdutoFinanceiro i_InterfaceProdutoFinanceiro;

        public AppProdutoFinanceiro(IProdutoFinanceiro a_IProdutoFinanceiro)
        {
            i_InterfaceProdutoFinanceiro = a_IProdutoFinanceiro;
        }

        public void Adicionar(ProdutoFinanceiro a_ProdutoFinanceiro)
        {
            i_InterfaceProdutoFinanceiro.Adicionar(a_ProdutoFinanceiro);
        }
        public void Atualizar(ProdutoFinanceiro a_ProdutoFinanceiro)
        {
            i_InterfaceProdutoFinanceiro.Atualizar(a_ProdutoFinanceiro);
        }
        public void Excluir(ProdutoFinanceiro a_ProdutoFinanceiro)
        {
            i_InterfaceProdutoFinanceiro.Excluir(a_ProdutoFinanceiro);
        }
        public ProdutoFinanceiro ObterPorId(int a_ProdutoFinanceiroID)
        {
            return new ProdutoFinanceiro();
        }
        public List<ProdutoFinanceiro> Listar()
        {
            return new List<ProdutoFinanceiro>();
        }
    }
}
