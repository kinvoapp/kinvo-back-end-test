using System;
namespace Aliquota.API.ViewModel
{
    public class ProdutoPostViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal TaxaAnual { get; set; }
        public DateTime Vencimento { get; set; }
        public ProdutoPostViewModel()
        {
        }
    }
}
