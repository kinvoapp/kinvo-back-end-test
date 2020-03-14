using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain
{
    class MainTester
    {
        static void Main(string[] args)
        {
            /*ProdutoFinanceiro prod1 = new ProdutoFinanceiro("Alberto", 3);

            prod1.novaDataIncialAplicacao(1, 5);
            prod1.novaDataFinalAplicacao(5, 4);

            prod1.calcularTempoAplicacao(prod1.cliente.getDataInicialAplicacao(), prod1.cliente.getDataFinalAplicacao());

            //Console.WriteLine(prod1.calcularTempoAplicacao(prod1.cliente.getDataInicialAplicacao(), prod1.cliente.getDataFinalAplicacao()));

            prod1.cliente.adicionarValorInvestido(1000);
            prod1.cliente.setLucro(100);
            Console.WriteLine(prod1.cliente.resgatar(100, prod1.getTempoTotalAplicacao()));*/

            int i = -1;

            Console.WriteLine("Seja bem vindo ao calculador de IR");

            Console.WriteLine("Digite o seu nome:");
            string nome = Console.ReadLine();
            
            Console.WriteLine("Digite o seu cpf:");
            int cpf = int.Parse(Console.ReadLine());

            ProdutoFinanceiro prod = new ProdutoFinanceiro(nome, cpf);

            while (i != 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Digite 0 para sair da aplicação");
                Console.WriteLine("Digite 1 para adicionar saldo");
                Console.WriteLine("Digite 2 para verificar o saldo");
                Console.WriteLine("Digite 3 para sacar");
                Console.WriteLine("");

                try
                {
                    i = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Por favor, insira um número");
                    //Esta mudança na variavel i foi colocada para que o usuario tenha a opção de escolher outras opcoes
                    i = -1;
                }

                if (i == 1)
                {
                    Console.WriteLine("Informe o valor para depósito:");
                    try
                    {
                        //Troca os pontos que foram usados no lugar da virgula
                        var valorDeposito = double.Parse(Console.ReadLine().Replace('.', ','));

                        prod.tratarDepositoCliente(valorDeposito);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Por favor, insira um número");
                        i = -1;
                    }
                }
                else if (i == 2)
                {
                    Console.WriteLine(prod.cliente.getNome() + ", o seu saldo é " + prod.cliente.getValorInvestidoMonetario());
                }
                else if (i == 3)
                {
                    Console.WriteLine("Digite o valor que deseja resgatar:");
                    double resgate = double.Parse(Console.ReadLine());
                    while(resgate <= 0)
                    {
                        Console.WriteLine("Valor inválido, por favor insira outro:");
                        resgate = double.Parse(Console.ReadLine());
                    }

                    Console.WriteLine("Digite o lucro que obteve durante este investimento:");
                    var lucro = double.Parse(Console.ReadLine());
                    while (lucro <= 0)
                    {
                        Console.WriteLine("Valor inválido, por favor insira outro:");
                        lucro = double.Parse(Console.ReadLine());
                    }
                    prod.cliente.setLucro(lucro);

                    Console.WriteLine("Digite o mês em que a aplicação foi feita(ex: 3):");

                    int mesInicial = int.Parse(Console.ReadLine());
                    while (mesInicial < 1 || mesInicial > 12)
                    {
                        Console.WriteLine("Digite um valor entre 1 e 12:");
                        mesInicial = int.Parse(Console.ReadLine());
                    }

                    Console.WriteLine("Digite o ano em que a aplicação foi feita");
                    int anoInicial = int.Parse(Console.ReadLine());
                    while (anoInicial <= 0)
                    {
                        Console.WriteLine("Valor inválido, por favor insira outro:");
                        anoInicial = int.Parse(Console.ReadLine());
                    }

                    Console.WriteLine("Digite o mês em que a aplicação será retirada");
                    
                    int mesFinal = int.Parse(Console.ReadLine());
                    while (mesFinal < 1 || mesFinal > 12)
                    {
                         Console.WriteLine("Digite um valor entre 1 e 12:");
                         mesFinal = int.Parse(Console.ReadLine());
                    }

                    Console.WriteLine("Digite o ano em que a aplicação será retirada");
                    int anoFinal = int.Parse(Console.ReadLine());
                    while (anoFinal <= 0)
                    {
                        Console.WriteLine("Valor inválido, por favor insira outro:");
                        anoFinal = int.Parse(Console.ReadLine());
                    }

                  

                    prod.cliente.inserirDataIncialAplicacao(mesInicial, anoInicial);
                    prod.cliente.inserirDataFinalAplicacao(mesFinal, anoFinal);
                    var tempoAplicacao = prod.calcularTempoAplicacao(prod.cliente.getDataInicialAplicacao(), prod.cliente.getDataFinalAplicacao());

                    Console.WriteLine(tempoAplicacao);


                    if (tempoAplicacao < 0)
                    {
                        Console.WriteLine("Não foi possível sacar, datas da aplicação inválidas");
                    }
                    else
                    {
                        Console.WriteLine("Foram debitados " + prod.tratarResgateCliente(resgate).ToString("C"));
                    }
           
                }
            }

        }
    }
}
