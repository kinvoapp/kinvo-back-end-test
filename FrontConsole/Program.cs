using System;
using Aliquota.Domain.Models;

namespace FrontConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AplicacaoContext())
            {
                var aplicacao = new Aplicacao();
                aplicacao.valorAplicacao = 1000;
                aplicacao.dataResgate = new DateTime(2020, 01, 02);
                aplicacao.dataAplicacao = new DateTime(2019, 03, 15);
                context.Aplicacoes.Add(aplicacao);
                context.SaveChanges();
                Console.WriteLine(aplicacao.ToString());

                var aplicacaoLeitura = context.Aplicacoes.Find(aplicacao.AplicacaoId);
                Console.WriteLine(aplicacaoLeitura.ToString());

                aplicacaoLeitura.valorAplicacao = 3000;
                context.SaveChanges();
                var aplicacaoEditada = context.Aplicacoes.Find(aplicacao.AplicacaoId);
                Console.WriteLine(aplicacaoEditada.ToString());

                context.Aplicacoes.Remove(aplicacaoLeitura);
                context.SaveChanges();
            }
        }
    }
}
