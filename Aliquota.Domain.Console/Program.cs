using Aliquota.Domain.AppConsole.Contexto;
using Aliquota.Domain.AppConsole.Negocio;
using Aliquota.Domain.AppConsole.Repositorio;
using Aliquota.Domain.AppConsole.View;

using Microsoft.EntityFrameworkCore;

using System;

namespace Aliquota.Domain.AppConsole
{
   class Program
   {
      //============================================================================================================================
      static ClienteBS    clienteBS    = new ClienteBS();
      static RendimentoBS rendimentoBS = new RendimentoBS();
      static AplicacaoBS  aplicacaoBS  = new AplicacaoBS();
      //============================================================================================================================
      static void Main(string[] args)
      {
         atualizarTabelas();
         processamento();
      }
      //============================================================================================================================
      //============================================================================================================================
      public static void processamento()
      {
         int opc = 0;

         opc = MenuView.getMenu();
         while ((opc >= 1) && (opc <= 6))
         {
            switch (opc)
            {
               case 1:
                  Views.ListarClientes();
                  break;
               case 2:
                  Views.ListarAplicacoes();
                  break;
               case 3:
                  Views.ListarResgates();
                  break;
               case 4:
                  Views.realizarAplicacao();
                  break;
               case 5:
                  Views.realizarResgate();
                  break;
               default:
                  Console.WriteLine("Default case");
                  break;
            }
            opc = MenuView.getMenu();
         }
      }
      //============================================================================================================================
      //============================================================================================================================

      public static void atualizarTabelas()
      {
         rendimentoBS.atualizarRendimentos();
         clienteBS.popularClientes();
         aplicacaoBS.atualizarAplicacoes();
      }
      //============================================================================================================================
      //============================================================================================================================

      public static void teste()
      {
         int i = 0;

         if (i == 1)
         {
            rendimentoBS.atualizarRendimentos();
            Rendimento x = rendimentoBS.GetRendimentoByData(DateTime.Now);
            Console.WriteLine(x.Data + " == " + x.Percentual);
         }

      }



   }
}
