using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.AggregatesModel.ProdutoFinanceiroAggregate
{
    public interface IProdutoFinanceiroRepository
    {
        ProdutoFinanceiro Add(ProdutoFinanceiro produtoFinanceiro);

        void Update(ProdutoFinanceiro produtoFinanceiro);

        public ProdutoFinanceiro GetProdutoFinanceiroById(int id);       

        public void Remove(ProdutoFinanceiro produtoFinanceiro);

    }
}
