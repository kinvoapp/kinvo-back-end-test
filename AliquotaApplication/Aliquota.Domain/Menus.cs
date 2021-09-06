using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain
{
    public class Menus
    {
        int x = 0;

        public void MenuResgateConsulta()
        {
            do
            {
                Console.Clear();

                Header();
                Console.WriteLine("\nQue tipo de operação deseja fazer?");
                Console.WriteLine("");
                Console.WriteLine("(1) Resgatar Aplicação \n(2) Consultar Aplicação");
                Console.WriteLine("\nDigite o número correspondente: ");
                int r = int.Parse(Console.ReadLine());

                if (r == 1)
                {
                    Cadastro c = new Cadastro();
                    c.GetResgate();
                    x = 1;
                }

                else if (r == 2)
                {
                    Cadastro c = new Cadastro();
                    c.GetConsulta();
                    x = 1;

                }
                else
                {
                    Console.WriteLine("Opção Inválida\n");
                }

            } while(x == 0);
            
      
        }

        public void MenuFazerAplicacao()
        {
            do
            {
                Console.Clear();

                Header();
                Console.WriteLine("Deseja fazer uma aplicação?  \n(1) Sim \n(2) Não");
                int r = int.Parse(Console.ReadLine());

                if (r == 2)
                {
                    Console.WriteLine("Tudo bem! A aplicação será encerrada!");
                    x = 1;
                }
                else if (r == 1)
                {
                    Cadastro c = new Cadastro();
                    c.GetCadastro();
                    x = 1;
                }
                else
                {
                    Console.WriteLine("Opção Inválida!\n");
                }
            } while (x == 0);
            
        }

        public void MenuFazerOutraOperacao()
        {
            Console.WriteLine("\nDeseja fazer outra operação? (1) Sim (2) Não");
            int r = int.Parse(Console.ReadLine());
            if (r == 2)
            {
                Console.WriteLine("\nAplicação foi encerrada!");
            }
            else if (r == 1)
            {
                this.MenuResgateConsulta();
            }
        }

        public void Header()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("* Bem-vindo ao AliquotaAPP! *");
            Console.WriteLine("*****************************");
            Console.WriteLine("");
        }


    }
}
