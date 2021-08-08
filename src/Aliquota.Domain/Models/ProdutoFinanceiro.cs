using Aliquota.Domain.Extensoes;
using Aliquota.Domain.Servicos.CalculoIR;
using System;

namespace Aliquota.Domain.Models
{
    public enum Status : int
    {
        EmAplicacao = 1,
        Resgatado = 2
    }

    public class ProdutoFinanceiro
    {
        public Guid Id { get; set; }
        public double ValorAplicado { get; set; }
        public double ValorIR { get; set; }
        public DateTime DataAplicacao { get; set; }
        public DateTime? DataResgate { get; set; }
        public Status Status { get; set; }
        public double Lucro
        {
            get => Math.Round((ValorAplicado / 100) * PorcentagemTotal(),2);
        }

        public Guid TipoProdutoFinanceiroFK { get; set; }
        public TipoProdutoFinanceiro TipoProdutoFinanceiro { get; set; }

        public void Resgatar(ICalculadorIR calculoIR, DateTime dataResgate)
        {
            DataResgate = dataResgate;
            Status = Status.Resgatado;
            ValorIR = calculoIR.CalculaIR(Lucro, DataAplicacao, dataResgate);
        }

        private double PorcentagemTotal()
        => (TipoProdutoFinanceiro.PorcentagemLucro *
            DataAplicacao.DiferencaDataAplicacaoEmMeses(DataResgate));

    }
}
