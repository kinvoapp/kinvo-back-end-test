using System;
using Aliquota.Domain.Models;
using Aliquota.Domain.Migrations;
using System.Collections.Generic;

namespace Aliquota.Domain
{
    class Program
    {
        static void Main(string[] args)
        {
            CriarCliente(001, "João");
            Console.ReadLine();
        }
        public static void CriarCliente(int idcliente,string nome)
        {
            using (var contexto = new AppDbContext())
            {
                var cliente = new Cliente
                {
                    Nome=nome,
                    IdCliente=idcliente
                };

                contexto.Clientes.Add(cliente);
                contexto.SaveChanges();
            }
        }
        public static void AplicarProduto(int idcliente,double capital,DateTime aniversario,double taxa)
        {
            if (capital<=0)
            {
                Console.WriteLine("Aplicação Invalida!!!");
                return;
            }
            else
            {
                using (var contexto = new AppDbContext())
                {
                    var cliente = contexto.Clientes.Find(idcliente);

                    var produto = new Produto
                    {
                        Capital = capital,
                        Aniversario = aniversario,
                        TaxaDeRendimento = taxa
                    };
                    contexto.Produtos.Add(produto);
                    contexto.SaveChanges();
                }
            }
        }
        public static void RetirarProduto(int idcliente, DateTime dataretirada,DateTime aniversario)
        {
            double IR;
            double capitalinicial;
            using (var contexto = new AppDbContext())
            {
                var produto = contexto.Produtos.Find(idcliente, aniversario);
                var mes = produto.Aniversario.Month - dataretirada.Month;
                var ano = produto.Aniversario.Year - dataretirada.Year;
                var diferenca = produto.Aniversario - dataretirada;
                capitalinicial = produto.Capital;
                if (dataretirada<produto.Aniversario)
                {
                    Console.WriteLine("Informe uma data validade de retirada!!!");
                    return;
                }
                else
                {
                    if (ano == 0)
                    {
                        if (mes==0)
                        {
                            IR = (produto.Capital * produto.TaxaDeRendimento) * 0.225;
                        }
                        else
                        {
                            IR = (produto.Capital * (produto.TaxaDeRendimento / mes)) * 0.225;
                        }
                    }
                    if (ano>=1 && ano<=2)
                    {
                        if (mes < 0)
                        {
                            IR = (produto.Capital * (produto.TaxaDeRendimento / (mes*-1))) * 0.225;
                        }
                        else
                        {
                            IR = (produto.Capital * (produto.TaxaDeRendimento / mes)) * 0.185;
                        }
                    }
                    if (ano>=2)
                    {
                        if (mes < 0)
                        {
                            IR = (produto.Capital * produto.TaxaDeRendimento / (mes * -1)) * 0.185;
                        }
                        else
                        {
                            IR = (produto.Capital * produto.TaxaDeRendimento) * 0.15;
                        }
                    }
                }
                contexto.Produtos.Remove(produto);
                contexto.SaveChanges();
            }
        }
    }
}