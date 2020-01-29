using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Interfaces
{
    public interface ICarteiraInvestimentos
    {
        CarteiraInvestimentos AdicionarCarteiraInvestimentos(ProdutoFinanceiro produtoFinanceiro, DateTime DataAplicacao, decimal ValorAplicacao);

        void ValidacaoAdicionarCarteiraInvestimentos(ProdutoFinanceiro produtoFinanceiro, decimal ValorAplicacao);
    }
}
