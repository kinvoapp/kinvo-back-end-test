using Alicota.View;
using System;

namespace Alicota
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao;

            do
            {
                Console.WriteLine("\n-- PROJETO ALICOTA DE IR --\n");
                Console.WriteLine("1 - Cadastrar Produto");
                Console.WriteLine("2 - Listar Produto");
                Console.WriteLine("3 - Resgatar Produto");
                opcao = Convert.ToInt32(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        ProdutoView.Cadastro();
                        break;
                    case 2:
                        ProdutoView.Listar();
                        break;
                    case 3:
                        ProdutoView.Resgate();
                        break;

                    default:
                        Console.WriteLine("Opção invalida");
                        break;
                }


            } while (opcao != 0);
        }
    }
}
