using Aliquota.Domain;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace AliquotaApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Menus v = new Menus();

            var cor = Console.ForegroundColor;
            var x = 0;
            do
            {
                try
                {

                    Console.ForegroundColor = cor;
                    v.Header();
                    Console.WriteLine("Olá, o Sr(a) já é um cliente? \n(1) Sim \n(2) Não");
                    Console.WriteLine("\nDigite o número correspondente: ");
                    int resposta = int.Parse(Console.ReadLine());
                    
                    if (resposta == 1)
                    {

                        v.MenuResgateConsulta();
                        x = 1;
                    }
                    else if (resposta == 2)
                    {
                        v.MenuFazerAplicacao();
                        x = 1;
                    }
                    else
                    {
                        Console.WriteLine("Opção Inválida!");
                    }
                }
                catch(FormatException)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nFormato Inválido\n");
                   
                }
                catch (InvalidOperationException)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nCadastro não encontrado, verifique seu nome de cadastro.\n");
                }
                catch(DbUpdateException)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nJá existe um cadastro com esse nome\n");
                }
                

            } while(x == 0);
            
        }
    }
}
