using Aliquota.Domain.ProdutoModule;
using Aliquota.Domain.Shared;
using System;

namespace Aliquota.Domain.AplicacaoModule
{
    public class Aplicacao : EntidadeBase
    {
        public Produto Produto { get; set; }
        public double Valor { get; set; }
        public double? Lucro { get; set; }
        public DateTime DataAplicacao { get; set; }
        public DateTime? DataResgate { get; set; }

        public Aplicacao()
        {
        }

        public Aplicacao(int id, Produto produto, double valor, DateTime dataAplicacao, DateTime? dataResgate)
        {
            Id = id;
            Produto = produto;
            Valor = valor;
            DataAplicacao = dataAplicacao;
            DataResgate = dataResgate;
        }

        public override string Validar()
        {
            string resultado = "";

            if (Valor <= 0)
                resultado += "A aplicação não pode ser igual ou menor que zero;\n";

            if (Produto == null)
                resultado += "O produto não pode ser nulo;\n";

            if (DataResgate < DataAplicacao)
                resultado += "A data de resgate não pode ser menor que a data de aplicação;\n";

            if (String.IsNullOrEmpty(resultado))
                resultado = "VALIDO";

            return resultado;
        }

        public double CalcularLucro(Aplicacao aplicacao, double lucro, DateTime dataResgate)
        {
            double taxaSobreLucro = 0;
            aplicacao.DataResgate = dataResgate;            

            if (DataAplicacao >= DateTime.Now.AddYears(-1))
                taxaSobreLucro = lucro * 0.225;
            else if (DataAplicacao < DateTime.Now.AddYears(-1) && DataAplicacao >= DateTime.Now.AddYears(-2))
                taxaSobreLucro = lucro * 0.185;
            else if (DataAplicacao < DateTime.Now.AddYears(-2))
                taxaSobreLucro = lucro * 0.15;

            double lucroFinal = lucro - taxaSobreLucro;

            return lucroFinal;
        }
    }
}
