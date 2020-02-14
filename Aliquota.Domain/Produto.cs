using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string ProdutoNome { get; set; }
        public double ValorAplicado { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataResgate { get; set; }
        public double TempoDeAplicacao { get; set; }
        public double Lucro { get; set; }
        public double Imposto { get; set; }

        private readonly Calculadora Calculadora;

        public Produto()
        {

        }

        public Produto(int produtoId, string produtoNome, double valorAplicado, string dataInicial, string dataResgate, double lucro)
        {
            ProdutoId = produtoId;
            ProdutoNome = produtoNome;
            ValorAplicado = Calculadora.ValorAplicado(valorAplicado);
            DataInicial = DateTime.Parse(dataInicial);
            DataResgate = DateTime.Parse(dataResgate);
            TempoDeAplicacao = Calculadora.DuracaoAplicado(dataInicial, dataResgate);
            Lucro = Calculadora.CalculaLucro(lucro);
            Imposto = Calculadora.AliquotaCalculada();
        }
    }
}
