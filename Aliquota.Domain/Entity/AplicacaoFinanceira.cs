using System;

namespace Aliquota.Domain.Entity
{
    public class AplicacaoFinanceira : EntityBase
    {
        public AplicacaoFinanceira() { }
        public AplicacaoFinanceira(Cliente cliente, ProdutoFinanceiro produto, DateTime dataAplicacao, DateTime? dataRetirada, decimal valor)
        {
            Cliente = cliente;
            Produto = produto;
            DataAplicacao = dataAplicacao;
            DataRetirada = dataRetirada;
            Valor = valor;
        }
        public virtual Cliente Cliente { get; set; }
        public virtual ProdutoFinanceiro Produto { get; set; }
        public DateTime DataAplicacao { get; set; }
        public DateTime? DataRetirada { get; set; }
        public decimal Valor { get; set; }
        public decimal GetRendimento(DateTime dataRetirada)
        {
            decimal montante = this.Valor * this.Produto.TaxaRedendimento;
            return montante - this.Valor;
        }
    }
}
