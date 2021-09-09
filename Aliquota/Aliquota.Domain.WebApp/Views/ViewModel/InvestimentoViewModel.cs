using Aliquota.Domain.Models;
using System.Collections.Generic;

namespace Aliquota.Domain.WebApp.Views.ViewModel
{
    public class InvestimentoViewModel
    {
        public Investimento Investimento { get; private set; }
        public IList<Produto> Produtos { get; private set; }

        public InvestimentoViewModel(IList<Produto> produtos)
        {
            this.Produtos = produtos;
        }

        public InvestimentoViewModel(Investimento investimento, IList<Produto> produtos)
        {
            this.Investimento = investimento;
            this.Produtos = produtos;
        }
    }
}
