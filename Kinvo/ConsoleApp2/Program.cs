 
#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Aliquota.App;
using Aliquota.CrossCuting;
using Aliquota.Domain;

#endregion

namespace ConsoleApp2
{
    internal class Program
    {
        #region Variaveis Globais

        private static List<Produto> _produtos;
        private static Servico _servico;
        private static bool _clienteExiste;
        private static Cliente _cliente;

        #endregion

        private static void Main(string[] args)
        {
            _produtos = new List<Produto>();
            
            try
            {
                var opt = "n";
                while (opt != "s")
                {
                    ImprimirHelp();
                    Console.Write("OPÇÃO: ");
                    var opt2 = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(opt2))
                    {
                        opt2 = opt2.ToLower();
                        if (opt2 != "s")
                            Funcao(opt2);
                        else
                            opt = opt2;
                    }
                    else
                    {
                        ErroMsg("COMANDO NÃO SUPORTADO");
                    }
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("UM ERRO INESPERADO OCORREU");
                Console.ResetColor();
                Console.ReadKey();
            }
        }


        private static void Funcao(string opt2)
        {
            if (opt2 != "1" && opt2 != "2" && opt2 != "3")
            {
                ErroMsg("COMANDO NÃO SUPORTADO");
            }
            else
            {
                if (!_clienteExiste)
                        IdentificarCliente();

                if (opt2 == "1")
                    Resgatar();
                else if (opt2 == "2")
                    CadastrarProduto(); 
                else if (opt2 == "3")
                    ListarProdutos();
                  
            }
        }
        private static void IdentificarCliente()
        {
            MontarHeader("IDENTIFICAR CLIENTE");
            Console.Write("NOME: ");
            var nome = Console.ReadLine();
            Console.WriteLine(""); 
            Console.WriteLine("[ 1 ] - CLIENTE COMUM");
            Console.WriteLine("[ 2 ] - CLIENTE ESPECIAL");
            Console.WriteLine("[ 3 ] - FUNCIONARIO");
            Console.WriteLine("");
            Console.Write("INFORME UMA OPÇÃO:");
            var tipo = Console.Read();
            TipoCliente tipo2 = TipoCliente.Comum;

            if (tipo == 2)
                tipo2 = TipoCliente.Especial;
            if (tipo == 3)
                tipo2 = TipoCliente.Funcionario;

            _cliente = new Cliente {Nome = nome, Tipo = tipo2};
            _servico = new Servico(_cliente,tipo2 );

            _clienteExiste = true;
        }

        private static void Resgatar()
        {
            bool quit = false;

            while (!quit)
            {
                MontarHeader("RESGATE");
                Console.ReadLine();
                InformacaoFiscal info;

                try
                {
                    Console.Write("INFORME O CODIGO DO PRODUTO: ");
                    var codigo = Console.ReadLine();

                    var existProd = ExisteProduto(codigo);
                    if (!existProd)
                    {
                        ErroMsg("ESTA APLICAÇÃO NÃO EXISTE");
                        Console.Write("DESEJA CONTINUAR? [N]");
                        var resp = Console.ReadLine();
                        quit = Fechar(resp);
                    }
                    else
                    {
                        Console.Write("INFORME O VALOR DO RESGATE: ");
                        var valor = Console.ReadLine();

                        Console.Write("INFORME A DATA DO RESGATE (DD/MM/AAAA): ");
                        var data = Console.ReadLine();

                        info = _servico.ClienteRealizaResgate(decimal.Parse(valor),int.Parse(codigo),Convert.ToDateTime(data));

                        Console.Clear();
                        MontarHeader("RESGATE");
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("RESGATE REALIZADO COM SUCESSO!");
                        if (info != null)
                        {

                            Console.WriteLine($"APLICAÇÃO: {info.Produto.Nome} IR RETIDO: {info.ValorRetido} ALIQ: {info.Aliquota} REND: {info.RedimentoAplicacao}");
                            Console.WriteLine($"SAQUE:{info.Saque} SALDO: {info.Produto.Saldo}");
                        }
    
                        Console.WriteLine("");
                        Console.ResetColor();
                        Console.Write("DESEJA CONTINUAR? [N]");
                        var resp = Console.ReadLine();
                        quit = Fechar(resp);
                    }
                    
                    
                }
                catch (Exception ex)
                {
                    ErroMsg($"UM ERRO OCORREU: {ex.Message}");
                }

            }
        }

        private static bool ExisteProduto(string codigo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(codigo))
                    return false;

                var produto = _produtos.FirstOrDefault(n => n.Id == int.Parse(codigo));
                return produto != null;
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }

        private static void CadastrarProduto()
        {
            bool quit = false;

            while (!quit)
            {
                MontarHeader("REGISTRAR APLICAÇÃO FINANCEIRA");
                Console.ReadLine();


                try
                {
                    Console.Write("NOME DO PRODUTO FINANCEIRO: ");
                    var nome = Console.ReadLine();

                    Console.Write("SALDO: ");
                    var saldo = Console.ReadLine();

                    Console.Write("RENDIMENTO (%): ");
                    var pRend = Console.ReadLine();

                    Console.Write("INFORME A DATA DA APLICAÇÃO (DD/MM/AAAA): ");
                    var data = Console.ReadLine();

                    Console.ReadLine();

                    var produto = new Produto
                    {
                            Nome = nome,
                            Data = Convert.ToDateTime(data),
                            Saldo = Convert.ToDecimal(saldo),
                            PercentualRedimento = Convert.ToDecimal(pRend),
                            Id = _produtos.Count + 1
                    };
                    

                    _servico.ClienteRealizaAplicacao(produto);
                    _produtos.Add(produto);

                    Console.Clear();
                    MontarHeader("REGISTRAR APLICAÇÃO FINANCEIRA");
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("CADASTRO REALIZADO COM SUCESSO!");
                    Console.WriteLine("");
                    Console.ResetColor();
                    Console.Write("DESEJA CONTINUAR? [N]");
                    var resp = Console.ReadLine();
                    quit = Fechar(resp);
                }
                catch (Exception ex)
                {
                    ErroMsg(ex.Message);
                }
                
            }
        }

        private static bool Fechar(string opt)
        {
             
            if (!string.IsNullOrWhiteSpace(opt))
            {
                opt = opt.ToLower();
                if (opt == "s") return true;

                return true;

            }
                return false;
             
        }

        private static void ListarProdutos()
        {
            MontarHeader("LISTA DE APLICAÇÕES");

            if (!_produtos.Any())
            {
                ErroMsg("Não ha produtos cadastrados");
            }
            else
            {
                foreach (var item in _produtos)
                {
                    Console.WriteLine($"COD:{item.Id} - {item.Nome} Saldo {item.Saldo} Data: {item.Data} %Rend {item.PercentualRedimento}");
                }

                Console.ReadLine();
            }
            
        }

        /// <summary>
        ///     Imprime o help do app.
        /// </summary>
        private static void ImprimirHelp()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("KINVO - AVALIAÇÃO .NET BACK-END - CANDIDATO: VALNEI B. FILHO (71) 9946-7636");
            Console.ResetColor();
            Console.Write("-----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("REALIZAR RESGATE       [1]");
            Console.WriteLine("");
            Console.WriteLine("REALIZAR APLICAÇÃO     [2]"); 
            Console.WriteLine("");
            Console.WriteLine("LISTAR APLICAÇÃO       [3]");
            Console.WriteLine("");
            Console.WriteLine("SAIR                   [S]");
            Console.WriteLine(
                    "-----------------------------------------------------------------------------------------------------------");
        }

        private static void MontarHeader(string titulo)
        {
             
            var cliente = _clienteExiste ? $" - CLIENTE: {_cliente.Nome}  - {_cliente.Tipo.Descricao()}" : "";
            var titulo2 = $"{titulo} {cliente}";
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            Console.WriteLine(titulo2);
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            Console.Write("");
            Console.Write("");
        }

        private static void ErroMsg(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{msg}");
            Console.ResetColor();
            Console.ReadKey();
        }
    }

     
}