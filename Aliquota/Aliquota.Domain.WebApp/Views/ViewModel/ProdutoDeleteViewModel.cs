using Aliquota.Domain.Models;

namespace Aliquota.Domain.WebApp.Views.ViewModel
{
    public class ProdutoDeleteViewModel
    {
        public Produto Produto { get; }
        public int QtdInvestimento { get; }

        public ProdutoDeleteViewModel(Produto produto, int qtdInvestimento)
        {
            Produto = produto;
            QtdInvestimento = qtdInvestimento;
        }
    }
}
