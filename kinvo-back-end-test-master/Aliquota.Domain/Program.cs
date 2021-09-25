using System;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using System.Data;
using Xunit;

namespace Aliquota.Domain
{
    class Test
    {
        public class Instancias
        {
            public DateTime dataAplicacao { get; set; }
            public DateTime dataResgate { get; set; }
            public double valorLucro { get; set; }
            public string diaHoje = DateTime.Now.ToString();
            public double diasDesdeAplicacao;
            public double tipoImposto;
            public double aplicacao1ano = 0.225;
            public double aplicacao1a2anos = 0.185;
            public double aplicacaoAcima2anos = 0.15;
            public double valorImposto;
        }

        static void Main(string[] args)
        {
            double CalculoImposto(double a_taxa, double a_valor)
            {
                double imposto = a_taxa * a_valor;
                return imposto;
            }

            double CalculoDiasAno(DateTime diaFinal, DateTime diaInicial)
            {
                double TotalDias = (diaFinal - diaInicial).TotalDays;
                return TotalDias;
            }
            
            //Setando a cultura para data ficar no formato correto.
            CultureInfo culture = new CultureInfo("pt-BR");
            
            string dataStringInicial = null;
            string dataStringFinal = null;
            var l_instancias = new Instancias();

            Console.WriteLine("Cálculo de IR \n Seja bem vindo. Seu imposto será de acordo com o lucro, data de aplicação e data de resgate.");
            Console.WriteLine("\nEscreva o valor do lucro do produto: \n");
            l_instancias.valorLucro = float.Parse(Console.ReadLine());
            Console.WriteLine("Favor, digite a data que aplicou o produto(DD/MM/AAAA) \n");
            dataStringInicial = Console.ReadLine();
            l_instancias.dataAplicacao = Convert.ToDateTime(dataStringInicial);
            Console.WriteLine("Favor, digite a data que resgatou o produto(DD/MM/AAAA) \n");
            dataStringFinal = Console.ReadLine();
            l_instancias.dataResgate = Convert.ToDateTime(dataStringFinal);

            //Erro da data de aplicação
            if (l_instancias.dataResgate < l_instancias.dataAplicacao)
            {
                Console.WriteLine("A data de resgate não pode ser menor a data de aplicação. Tente novamente.");
                Environment.Exit(0);
            }

            l_instancias.diasDesdeAplicacao = CalculoDiasAno(l_instancias.dataResgate, l_instancias.dataAplicacao);
            if (l_instancias.diasDesdeAplicacao < 365)
            {
                l_instancias.tipoImposto = l_instancias.aplicacao1ano;
            }
            if (l_instancias.diasDesdeAplicacao > 365 && l_instancias.diasDesdeAplicacao < 730)
            {
                l_instancias.tipoImposto = l_instancias.aplicacao1a2anos;
            }
            if (l_instancias.diasDesdeAplicacao > 730)
            {
                l_instancias.tipoImposto = l_instancias.aplicacaoAcima2anos;
            }

            l_instancias.valorImposto = CalculoImposto(l_instancias.tipoImposto, l_instancias.valorLucro);
            Console.WriteLine("Seu IR é de R${0}", l_instancias.valorImposto);
        }
    }

}
