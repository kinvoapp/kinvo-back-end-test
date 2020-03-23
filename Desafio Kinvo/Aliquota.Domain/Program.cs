using Aliquota.Domain.Models;
using Aliquota.Domain.Repository;
using System;
using System.Collections.Generic;

namespace Aliquota.Domain
{
    class Program
    {

        public static void Main(string[] args)
        {

            bool powerOn = true;

            var repository= new RDefault();

            Console.WriteLine("Programa iniciado ");

            do
            {
                Console.WriteLine("\n \n Escolha: \n" +
                                    "1) Nova Investimento; \n" +
                                    "2) Consultar Investimentos; \n" +
                                    "3) Retirar Investimento; \n\n" +
                                    "0) Sair; \n\n");

                switch (Console.ReadLine())
                {
                    case "0":
                        {
                            Console.WriteLine("\n Pressione qualquer tecla para encerrar.");
                            powerOn = false;

                        }
                        break;
                    case "1":
                        {
                            Investment newInvestment = new Investment();
                            try
                            {

                                Console.WriteLine("\n Insira o nome de usuário: ");
                                newInvestment.nickname = Console.ReadLine();

                                Console.WriteLine("\n Insira quantidade de meses que deseja investir: ");
                                newInvestment.period = int.Parse(Console.ReadLine());

                                Console.WriteLine("\n Insira valor a ser insvestido:");
                                newInvestment.amountBegin = decimal.Parse(Console.ReadLine());

                            }
                            catch (Exception)
                            {
                                    Console.WriteLine(" \n " + repository.ValInfo(newInvestment));
                            }

                            if (repository.ValInfo(newInvestment) == "Novo investimento adcicionado!")
                            {
                                repository.Add(newInvestment);
                            }
                        }
                        break;
                    case "2":
                        {
                            Console.WriteLine(" \n \n Simulações : ");
                            Console.WriteLine(
                                  "\n Id |" +
                                  "|    Conta     |" +
                                  "| Investimento |" +
                                  "| Nº de Meses  |" +
                                  "|    Lucro     |" +
                                  "|  Acumulado   |" +
                                  "|  Imposto %   |" +
                                  "| Valor de Retirada | " +
                                  "| Iniciado em  |\n");

                            for (int i = 0; i < repository.GetList().Count; i++)
                            {
                                Console.WriteLine(
                                    " " + repository.GetList()[i].id + " " +
                                    "\t " + repository.GetList()[i].nickname + " \t " +
                                    "\t $ " + repository.GetList()[i].amountBegin + " " +
                                    "\t " + repository.GetList()[i].period + " " +
                                    "\t\t $ " + decimal.Parse( repository.GetList()[i].gain.ToString()) + " " +
                                    "\t $ " + decimal.Parse(repository.GetList()[i].amount.ToString()) + " " +
                                    "\t " + repository.GetList()[i].tax + "% " +
                                    "\t  $ " + decimal.Parse(repository.GetList()[i].canRecover.ToString()) + " " +
                                    "\t\t" + repository.GetList()[i].started.ToShortDateString() + " " ); ;
                            }

                        }
                        break;
                    case "3" : 
                        {
                            Console.WriteLine("\n Inseira o id do investimento que deseja remover:");

                            int id = new int();
                            try
                            {
                                id = int.Parse(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                            }
                            if (repository.Remove(id) != null)
                            {
                                repository.Remove(id);
                                Console.WriteLine("\n Investimento Removido com sucesso!");
                            }
                            else {
                                Console.WriteLine("\n Investimento não encontrado:");
                            }

                        }
                        break;
                }

            } while (powerOn);




            Console.ReadKey();
        }



    }
}
