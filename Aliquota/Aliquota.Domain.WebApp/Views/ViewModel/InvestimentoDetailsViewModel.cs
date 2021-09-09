using Aliquota.Domain.Models;

namespace Aliquota.Domain.WebApp.Views.ViewModel
{
    public class InvestimentoDetailsViewModel
    {
        public Investimento Investimento { get; }
        public RendimentoInvest Rendimento { get; }

        public InvestimentoDetailsViewModel(Investimento investimento, RendimentoInvest rendimento)
        {
            this.Investimento = investimento;
            this.Rendimento = rendimento;
        }
    }
}
