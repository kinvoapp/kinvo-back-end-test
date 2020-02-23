using System;

namespace Aliquota.Domain
{
    class Program
    {
        static void Main(string[] args)
        {
            var cliente = new Cliente("Johnny", "11122233345");
            var produto = new Produto("Tesouro Indireto", 0.07);

            var aplicacao = new OperadorIR(cliente, produto);

            aplicacao.Aplicar(2000);
            Console.WriteLine(aplicacao.Resgatar(new DateTime(2020, 8, 23)));
            
            Console.ReadLine();
        }
    }
}
