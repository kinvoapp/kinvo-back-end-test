using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aliquota.Domain
{
    public class Cadastro : Cliente
    {
        Cliente Titular { get; set; }
        private AliquotaContext contexto;
        

        public Cadastro(string nome, decimal valorAplicado)
        {
            
            this.contexto = new AliquotaContext();
            Titular = new Cliente();
            
            Titular.Nome = nome;
            Titular.ValorAplicado = valorAplicado;
            Titular.DataDeAplicacao = DateTime.Today;

            this.Adicionar(Titular);

        }


        public Cadastro()
        {
            this.contexto = new AliquotaContext();
            
        }

        public void GetCadastro()
        {
            var x = 0;
            do
            {
                Menus v = new Menus();
                Console.WriteLine("\nDigite seu nome: ");
                string nome = Console.ReadLine();

                Console.WriteLine("\nValor que gostaria de aplicar: \n");
                decimal valorAplicado = Decimal.Parse(Console.ReadLine());
                if (valorAplicado <= 0)
                {
                    Console.WriteLine("O valor da aplicação não pode ser igual ou menor que 0\n");
                }
                else
                {
                    Cadastro c = new Cadastro(nome, valorAplicado);


                    Console.WriteLine("\nCadastro Efetuado!");

                    v.MenuFazerOutraOperacao();
                    x = 1;

                }

            }while(x == 0);

        }

        public void GetResgate()
        {
            Menus v = new Menus();
            AliquotaContext contexto = new AliquotaContext();
            var x = 0;
            
            
            Console.Clear();
            v.Header();
            do 
            { 
                Console.WriteLine("Digite o nome cadastrado: ");
                string nomeCadastrado = Console.ReadLine();

                var buscar = contexto.Clientes.Single(b => b.Nome.Equals(nomeCadastrado));

                Console.WriteLine("\nQuando gostaria de resgatar sua aplicação? (Obs: Data de resgate não pode ser menor que a data de aplicação) \n\nDigite a data seguindo o exemplo > Ex: dd/mm/aaaa");
                DateTime dataResgate = DateTime.Parse(Console.ReadLine());
                var dataAplicada = buscar.DataDeAplicacao;

                if (dataResgate >= dataAplicada)
                {
                    var valor = buscar.ValorAplicado;

                    CalcularAliquota c = new CalcularAliquota();
                    c.GetAliquota(valor, dataResgate, dataAplicada);

                    contexto.Clientes.Remove(buscar);
                    contexto.SaveChanges();
                    v.MenuFazerOutraOperacao();
                    x = 1;

                }
                else
                {
                    Console.WriteLine("\nA data do resgate não pode ser menor que a data de aplicação!\n");

                }
            } while (x == 0);
        }

        public void GetConsulta()
        {
            Menus v = new Menus();
            Console.Clear();
            v.Header();

            Console.WriteLine("Digite o nome cadastrado: ");
            string nomeCadastro = Console.ReadLine();

            AliquotaContext contexto = new AliquotaContext();
            var consulta = contexto.Clientes.Single(b => b.Nome.Equals(nomeCadastro));
            Console.WriteLine(consulta);

            v.MenuFazerOutraOperacao();
        }

        public void Adicionar(Cliente p)
        {
            contexto.Clientes.Add(p);
            contexto.SaveChanges();
        }

        
  

      
    }
}
