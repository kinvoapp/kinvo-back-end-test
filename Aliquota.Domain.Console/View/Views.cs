
using Aliquota.Domain.AppConsole.Negocio;

using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.AppConsole.View
{
   class Views
   {

      private static ClienteBS    clienteBS    = new ClienteBS();
      private static AplicacaoBS  aplicacaoBS  = new AplicacaoBS();
      private static RendimentoBS rendimentoBS = new RendimentoBS();
      private static ResgateBS    resgateBS    = new ResgateBS();

      public static void ListarClientes()
      {
         Console.Clear();
         Console.WriteLine();
         Console.WriteLine();
         Console.WriteLine("Lista dos Clientes");
         Console.WriteLine();
         Console.WriteLine("Id         Nome");
         Console.WriteLine("===        =====================");
         foreach (Cliente cliente in clienteBS.getAll())
         {
            Console.WriteLine(String.Format("{0}          {1}", cliente.ClienteId, cliente.Nome));
         }
         Console.WriteLine();
         Console.WriteLine("Pressione qualquer tecla");
         Console.ReadKey();

      }

      public static Cliente getCliente()
      {
         int     id;
         Cliente cliente = null;

         Console.WriteLine();
         Console.WriteLine("Digite o id do Cliente");
         Console.WriteLine();

         try
         {
            id = Int32.Parse(Console.ReadLine());
            cliente = clienteBS.GetById(id);
            if (cliente == null)
            {
               throw new Exception("Cliente não localizado.");
            }
         }
         catch (FormatException ex)
         {
            Console.WriteLine("Id inválido. Pressione qualquer tecla");
            Console.ReadKey();
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message+ "Pressione qualquer tecla");
            Console.ReadKey();
         }
         return cliente;
      }

      public static void ListarAplicacoes()
      {

         Cliente cliente;
         decimal lucro;
         decimal ir;
         decimal lucroLiquido;

         cliente = getCliente();
         if (cliente != null)
         {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Cliente  Id => {0}     Nome => {1}",cliente.ClienteId, cliente.Nome);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Lista das Aplicações");
            Console.WriteLine();
            Console.WriteLine("Id    Data Aplicação   Valor Aplicado    Valor Atual    Lucro            IR           Lucro Líquido");
            Console.WriteLine("===   ==============   ==============    ===========    ============     ==========   =============");


            cliente.Aplicacoes.Sort((x, y) => x.DataMov.CompareTo(y.DataMov));
            foreach (Aplicacao aplicacao in cliente.Aplicacoes) 
            {

               lucro = aplicacao.ValorAtual - aplicacao.ValorAplicado;
               ir = 0;
               if (lucro > 0)
               {
                  ir = aplicacaoBS.getValorIR(aplicacao.DataMov, aplicacao.DataAtual, lucro);
               }
               lucroLiquido = lucro - ir;
               Console.WriteLine(String.Format("{0}     {1} {2} {3} {4}  {5}  {6}",
                                       aplicacao.AplicacaoId.ToString().PadLeft(2),
                                       aplicacao.DataMov.ToString("dd/MM/yyyy"),
                                       aplicacao.ValorAplicado.ToString().PadLeft(18),
                                       aplicacao.ValorAtual.ToString().PadLeft(15),
                                       lucro.ToString().PadLeft(15),
                                       ir.ToString().PadLeft(13),
                                       lucroLiquido.ToString().PadLeft(14)
                                       ));
            }
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla");
            Console.ReadKey();
         }
      }

      public static void ListarResgates()
      {

         Cliente cliente;
         decimal lucro;
         decimal ir;
         decimal valorResgatado;

         cliente = getCliente();
         if (cliente != null)
         {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Cliente  Id => {0}     Nome => {1}", cliente.ClienteId, cliente.Nome);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Lista dos Resgates");
            Console.WriteLine();
            Console.WriteLine("Id    Data Resgate     Valor Solicitado        IR                Valor Resgatado");
            Console.WriteLine("===   ==============   =================       ============      ===============");


            cliente.Resgates.Sort((x, y) => x.DataMov.CompareTo(y.DataMov));
            foreach (Resgate resgate in cliente.Resgates)
            {

               valorResgatado = resgate.Valor - resgate.IR;
               Console.WriteLine(String.Format("{0}     {1} {2} {3} {4} ",
                                       resgate.ResgateId.ToString().PadLeft(2),
                                       resgate.DataMov.ToString("dd/MM/yyyy"),
                                       resgate.Valor.ToString().PadLeft(18),
                                       resgate.IR.ToString().PadLeft(20),
                                       valorResgatado.ToString().PadLeft(20)
                                       ));
            }
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla");
            Console.ReadKey();
         }
      }

      public static void realizarAplicacao()
      {

         Cliente cliente;
         decimal valor = 0;
         DateTime dtAplicacao = DateTime.Now;

         string  info;
         bool    erro;

         cliente = getCliente();
         if (cliente != null)
         {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Cliente  Id => {0}     Nome => {1}", cliente.ClienteId, cliente.Nome);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Dados da Aplicação");
            Console.WriteLine();
            Console.WriteLine("Digite o Valor a ser aplicado");
            info = Console.ReadLine();
            erro = false;
            try
            {
               valor = Convert.ToDecimal(info);
               if (valor <= 0)
               {
                  throw new Exception("Valor deve ser superior a zero.");
               }
            }
            catch (Exception ex)
            {
               if (ex is FormatException || ex is OverflowException)
               {
                  Console.WriteLine("Valor inválido. Pressione qualquer tecla");
               }
               else
               {
                  Console.WriteLine(ex.Message + " Pressione qualquer tecla");
               }
               Console.ReadKey();
               erro = true;
            }
            if (!erro)
            {
               Console.WriteLine();
               Console.WriteLine("Digite a Data da aplicação");
               info = Console.ReadLine();
               try
               {
                  dtAplicacao = Convert.ToDateTime(info);
                  if ((rendimentoBS.getMaxDataRendimento() != null) && (rendimentoBS.getMinDataRendimento() != null))
                  {
                     if ((dtAplicacao < rendimentoBS.getMinDataRendimento()) || (dtAplicacao > rendimentoBS.getMaxDataRendimento()))
                     {
                        throw new Exception(String.Format("A Data da aplicação deve estar entre {0} e {1}",
                                                                    rendimentoBS.getMinDataRendimento(),
                                                                    rendimentoBS.getMaxDataRendimento()
                                                         ));
                     }
                  }
                  else
                  {
                     throw new Exception("Erro no sistema. Tabela de Rendimentos não Atualizada");

                  }
               }
               catch (Exception ex)
               {
                  if (ex is FormatException)
                  {
                     Console.WriteLine("Data inválida. Pressione qualquer tecla");
                  }
                  else
                  {
                     Console.WriteLine(ex.Message + " Pressione qualquer tecla");
                  }
                  Console.ReadKey();
                  erro = true;
               }

            }
            if (!erro)
            {
               Aplicacao aplicacao = new Aplicacao
               {
                  DataMov = dtAplicacao,
                  ValorAplicado = valor,
                  ClienteId = cliente.ClienteId,
                  DataAtual = dtAplicacao,
                  ValorAtual = valor
               };


               aplicacaoBS.save(aplicacao);
               aplicacaoBS.saveChanges();

               aplicacaoBS.atualizarAplicacao(aplicacao);
               aplicacaoBS.saveChanges();
               Console.WriteLine();
               Console.WriteLine("Aplicação feita com sucesso. Pressione qualquer tecla");
               Console.ReadKey();
            }
         }
      }
      public static void realizarResgate()
      {

         Cliente cliente;
         decimal lucro;
         decimal ir;
         decimal irResgate = 0;
         decimal lucroLiquido;
         decimal totalAplicado = 0;

         decimal valor = 0;
         decimal valorOriginal = 0;
         DateTime dtAplicacao = DateTime.Now;

         string info;
         bool erro;

         List<Aplicacao> aplicacoesResgatadas = new List<Aplicacao>();

         int ind;

         cliente = getCliente();
         if (cliente != null)
         {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Cliente  Id => {0}     Nome => {1}", cliente.ClienteId, cliente.Nome);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Lista das Aplicações");
            Console.WriteLine();
            Console.WriteLine("Id    Data Aplicação   Valor Aplicado    Valor Atual    Lucro            IR           Lucro Líquido");
            Console.WriteLine("===   ==============   ==============    ===========    ============     ==========   =============");


            cliente.Aplicacoes.Sort((x, y) => x.DataMov.CompareTo(y.DataMov));
            foreach (Aplicacao ap in cliente.Aplicacoes)
            {

               lucro = ap.ValorAtual - ap.ValorAplicado;
               ir = 0;
               if (lucro > 0)
               {
                  ir = aplicacaoBS.getValorIR(ap.DataMov, ap.DataAtual, lucro);
               }
               lucroLiquido = lucro - ir;

               totalAplicado += ap.ValorAtual;
               Console.WriteLine(String.Format("{0}     {1} {2} {3} {4}  {5}  {6}",
                                       ap.AplicacaoId.ToString().PadLeft(2),
                                       ap.DataMov.ToString("dd/MM/yyyy"),
                                       ap.ValorAplicado.ToString().PadLeft(18),
                                       ap.ValorAtual.ToString().PadLeft(15),
                                       lucro.ToString().PadLeft(15),
                                       ir.ToString().PadLeft(13),
                                       lucroLiquido.ToString().PadLeft(14)
                                       ));
            }

            Console.WriteLine();
            Console.WriteLine("Valor máximo sem imposto para resgate: "+totalAplicado);
            Console.WriteLine();

            if (totalAplicado > 0)
            {
               Console.WriteLine();
               Console.WriteLine();
               Console.WriteLine("Dados do Resgate");
               Console.WriteLine();
               Console.WriteLine();
               Console.WriteLine("Data do Resgate => " + DateTime.Now.Date);
               Console.WriteLine();
               Console.WriteLine("Digite o Valor a ser resgatado");
               info = Console.ReadLine();
               erro = false;
               try
               {
                  valor = Convert.ToDecimal(info);
                  valorOriginal = valor;
                  if ((valor <= 0) || (valor > totalAplicado))
                  {
                     throw new Exception("Valor deve ser superior a zero e inferior a " + totalAplicado + ".");
                  }
               }
               catch (Exception ex)
               {
                  if (ex is FormatException || ex is OverflowException)
                  {
                     Console.WriteLine("Valor inválido. Pressione qualquer tecla");
                  }
                  else
                  {
                     Console.WriteLine(ex.Message + " Pressione qualquer tecla");
                  }
                  Console.ReadKey();
                  erro = true;
               }
               if (!erro)
               {
                  ind = 0;
                  cliente.Aplicacoes.Sort((x, y) => x.DataMov.CompareTo(y.DataMov));
                  while ((ind < cliente.Aplicacoes.Count) && (valor > 0))
                  {
                     Aplicacao apli = cliente.Aplicacoes[ind];

                     if (valor >= apli.ValorAtual)
                     {
                        valor = valor - apli.ValorAtual;
                        apli.ValorAtual = 0;
                     }
                     else
                     {
                        apli.ValorAtual = apli.ValorAtual - valor;
                        valor = 0;
                     }

                     lucro = apli.ValorAtual - apli.ValorAplicado;
                     ir = 0;
                     if (lucro > 0)
                     {
                        ir = aplicacaoBS.getValorIR(apli.DataMov, apli.DataAtual, lucro);
                     }
                     irResgate += ir;
                     aplicacoesResgatadas.Add(apli);

                     aplicacaoBS.Update(apli);
                     aplicacaoBS.saveChanges();
                     ind++;
                  }
                  Resgate res = new Resgate
                  {
                     DataMov = DateTime.Now.Date,
                     Valor = valorOriginal,
                     IR = irResgate,
                     ClienteId = cliente.ClienteId
                  };
                  resgateBS.save(res);
                  resgateBS.saveChanges();
                  Console.WriteLine();
                  Console.WriteLine("Resgate feito com sucesso. Pressione qualquer tecla");
                  Console.ReadKey();
               }
            }
            else
            {
               Console.WriteLine();
               Console.WriteLine("Valor insuficiente para resgate. Pressione qualquer tecla");
               Console.ReadKey();

            }


         }
      }

   }
}
