using Alicota.Controller;
using Alicota.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alicota.View
{
    class ProdutoView
    {
        static string nome, dataAplicacao, dataResgate;
        static decimal valorAplicado, valorResgatado;
        public static void Cadastro()
        {
            //Produto produto;

            

            Console.WriteLine("\n-- CADASTRO DO PRODUTO --\n");
            Console.WriteLine("Digite o nome do Produto");
            nome = Console.ReadLine();
            Console.WriteLine("Digite a data da aplicação");
            dataAplicacao = Console.ReadLine();
            Console.WriteLine("Digite o valor aplicado");
            valorAplicado = Convert.ToDecimal(Console.ReadLine());

            try
            {
                Produto produto = new Produto{ NomeProduto = "EMBR3", DataAplicacao = Convert.ToDateTime("03/08/2020"), ValorAplicado = 200.54M };
                Produto produto1 = new Produto { NomeProduto = "TIMS3", DataAplicacao = Convert.ToDateTime("03/08/2021"), ValorAplicado = 200.54M };
                //produto.NomeProduto = nome;
                //produto.DataAplicacao = Convert.ToDateTime(dataAplicacao);
                //produto.ValorAplicado = valorAplicado;
                ProdutoController.CadastroProduto(produto);
                ProdutoController.CadastroProduto(produto);
                ProdutoController.CadastroProduto(produto1);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public static void Listar()
        {
            Console.WriteLine("\n-- LISTA DE PRODUTOS --\n");
            List<Produto> produto = ProdutoController.ListarProdutos();

            foreach(var item in produto)
            {
                Console.WriteLine(String.Format("ID - {0}\nProtudo - {1}\nData da aplicação - {2}\nValor aplicado - {3}\nData do resgate - {4}\nValor do Resgate - {5}\n", item.ID, item.NomeProduto, item.DataAplicacao, item.ValorAplicado, item.DataResgate, item.ValorResgatado));
            }
        }

        public static void Resgate()
        {
            Console.WriteLine("\n-- RESGATE DE PRODUTO --\n");
            Console.WriteLine("Digite o nome do produto para resgate");
            nome = Console.ReadLine();
            Console.WriteLine("Digite a data do resgate");
            dataResgate = Console.ReadLine();
            Console.WriteLine("Digite o valor resgatado");
            valorResgatado = Convert.ToDecimal(Console.ReadLine());

            if (nome == "")
                Console.WriteLine("Nome do produto não pode ser vazio");
            try
            {
                ProdutoController.ResgateProduto(nome, dataResgate, valorResgatado);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
           
        }
    }
}
