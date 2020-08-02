using System;
namespace Aliquota.API.ViewModel
{
    public class InvestimentoPostViewModel
    {

        public Guid CarteiraGuid { get; set; }
        public int Id { get; set; }
        public decimal ValorInvestimento { get; set; }
        public InvestimentoPostViewModel()
        {
        }
    }
}
