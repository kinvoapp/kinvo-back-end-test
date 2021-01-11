using Aliquota.Domain.Model;
using System;

namespace Aliquota.Domain
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ReadLine(); 
            
        }


        static void AdicionardCliente()
        {
            using (var cli = new ClienteContexto())
            {
                Cliente cliente = new Cliente() { Nome_cliente = "Junior", Valor_investido = 10000,Data_investimento = Convert.ToDateTime("10-11-1990")};
                cli.clientes.Add(cliente);
                cli.SaveChanges();
            }
        }
        static void resgatarIvetimeto()
        {
            using (var cli = new ClienteContexto())
            {
                Cliente cliente = new Cliente() { Id_cliente = 1, Nome_cliente=""};


        }
    }
}
