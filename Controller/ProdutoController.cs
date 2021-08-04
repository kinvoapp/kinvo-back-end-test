using Alicota.Models;
using Alicota.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alicota.Controller
{
    class ProdutoController
    {
        public static List<Produto> produtos = new List<Produto>();

        public static void CadastroProduto(Produto produto)
        {
            bool produtoEncontrado = false;
            foreach (Produto item in produtos)
            {
                if (item.NomeProduto == produto.NomeProduto)
                {
                    Console.WriteLine("Produto já cadastrado");
                    produtoEncontrado = true;
                }
            }
            if (produtoEncontrado != true)
                produtos.Add(produto);
            Console.WriteLine("Produto cadastrado com sucesso");
        }

        public static List<Produto> ListarProdutos()
        {
            return produtos;
        }

        public static void ResgateProduto(string nome, string data, decimal valor)
        {
            for (int i = 0; i < produtos.Count; i++)
            {
                if(produtos[i].NomeProduto.ToLower() == nome.ToLower())
                {
                    produtos[i].DataResgate = Convert.ToDateTime(data);
                    produtos[i].ValorResgatado = valor;
                    decimal valorAplicado = produtos[i].ValorAplicado;
                    Calcula.Alicota(valorAplicado, valor, produtos[i].DataAplicacao, Convert.ToDateTime(data));
                }
                
            }
        }
    }
}
