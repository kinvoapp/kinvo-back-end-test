using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.AppConsole.View
{
   class MenuView
   {

      public static int getMenu()
      {
         int opc = 0;
         while (((opc < 1) || (opc > 5)) && (opc != 9))
         {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("                             MENU");
            Console.WriteLine();
            Console.WriteLine("1 - Listar os clientes");
            Console.WriteLine("2 - Listar as aplicaçoes de um cliente");
            Console.WriteLine("3 - Listar os resgates   de um cliente");
            Console.WriteLine("4 - Fazer uma aplicação");
            Console.WriteLine("5 - Fazer um  resgate");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("9 - Sair");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("        Informe a sua opção  ");
            try
            {
               opc = Int32.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
               Console.WriteLine("Valor inválido. Pressione qualquer tecla");
               Console.ReadKey();
               opc = 0;
            }

         }
         return opc;



      }


   }
}
