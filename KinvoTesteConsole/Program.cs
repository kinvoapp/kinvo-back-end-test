using KinvoTeste.Models;
using KinvoTesteConsole.Service;
using System;
using System.Linq;

namespace KinvoTesteConsole
{
    class Program
    {
        private static Usuario usuarioLogado;

        static void Main(string[] args)
        {
            while(true)
                Inicial();
        }

        static void Inicial()
        {
            Console.WriteLine("1 - Abrir Conta");
            Console.WriteLine("2 - Logar");
            Console.Write("Digite a opção: ");
            var opcao = Console.ReadKey();

            if (opcao.KeyChar == '1')
                AbrirConta();
            else if (opcao.KeyChar == '2')
                Logar();
            else
            {
                Console.WriteLine("Opção inválida");
                Inicial();
            }
        }

        static void AbrirConta()
        {
            Console.Write("\nNovo login: ");
            var login = Console.ReadLine();
            Console.Write("Senha: ");
            var senha = Console.ReadLine();
            var service = new UsuarioService();
            if(service.NovoUsuario(login, senha))
            {
                Console.WriteLine("\nUsuario Criado\n");
            }
            Inicial();
        }

        static void Logar()
        {
            Console.Write("\nlogin: ");
            var login = Console.ReadLine();
            Console.Write("Senha: ");
            var senha = Console.ReadLine();
            var service = new UsuarioService();
            var usuario = service.Login(login, senha);
            if (usuario != null)
            {
                Console.WriteLine("\nUsuario Logado\n");
                ExibirUsuario(usuario);
            }
        }

        static void ExibirUsuario(Usuario usuario)
        {
            usuarioLogado = usuario;
            Console.WriteLine($"Saldo: {usuario.Contas.FirstOrDefault()?.Saldo:C}");
            if (usuario.Produtos != null && usuario.Produtos.Count > 0)
            {
                Console.WriteLine("Inventimentos:");
                Console.WriteLine($"Valor Investido:{usuario.Produtos.Sum(x => x.ValorInvestido):C}");
                Console.WriteLine($"Valor Bruto:{usuario.Produtos.Sum(x => x.ValorBruto):C}\n");
            }
            OpcoesLogado();
        }

        static void OpcoesLogado()
        {
            Console.WriteLine("1 - Depositar");
            Console.WriteLine("2 - Investir");
            Console.WriteLine("3 - Resgatar");
            Console.WriteLine("4 - Simular Resgate");
            Console.Write("Digite a opção: ");
            var opcao = Console.ReadKey();

            if (opcao.KeyChar == '1')
                Depositar();
            else if (opcao.KeyChar == '2')
                Investir();
            else if (opcao.KeyChar == '3')
                Resgatar();
            else if (opcao.KeyChar == '4')
                Simular();
            else
            {
                Console.WriteLine("Opção inválida");
                OpcoesLogado();
            }
        }

        static void Depositar()
        {
            Console.Write("\nValor a depositar: ");
            var valorString = Console.ReadLine();
            
            var service = new ContaService();
            if (service.Depositar(valorString, usuarioLogado))
            {
                Console.WriteLine("\nDepósito Realizado\n");

                var serviceUsuario = new UsuarioService();
                var usuario = serviceUsuario.Obter(usuarioLogado.Id);
                if (usuario != null)
                {
                    ExibirUsuario(usuario);
                }
            } 
            else
            {
                OpcoesLogado();
            }
        }
        
        static void Investir()
        {
            Console.Write("\nValor a aplicar: ");
            var valorString = Console.ReadLine();
            Console.Write("Data a aplicar (dd/MM/yyyy - ou digite: hoje): ");
            var dataString = Console.ReadLine();

            var service = new ProdutoService();
            if (service.Investir(valorString, dataString, usuarioLogado))
            {
                Console.WriteLine("\nInvestimento Realizado\n");

                var serviceUsuario = new UsuarioService();
                var usuario = serviceUsuario.Obter(usuarioLogado.Id);
                if (usuario != null)
                {
                    ExibirUsuario(usuario);
                }
            }
            else
            {
                OpcoesLogado();
            }
        }
        
        static void Simular()
        {
            Console.Write("\nData de resgate (dd/MM/yyyy - ou digite: hoje): ");
            var dataString = Console.ReadLine();

            var service = new ProdutoService();
            var resgates = service.Simular(dataString, usuarioLogado.Id);
            if (resgates != null)
            {
                Console.WriteLine($"Valor Investido: {resgates.Sum(x => x.ValorInvestido):C}");
                Console.WriteLine($"Valor Bruto: {resgates.Sum(x => x.ValorBruto):C}");
                Console.WriteLine($"Lucro Bruto: {resgates.Sum(x => x.LucroBruto):C}");
                Console.WriteLine($"Valor IR: {resgates.Sum(x => x.ValorIR):C}");
                Console.WriteLine($"Lucro Liquido: {resgates.Sum(x => x.LucroLiquido):C}");
                Console.WriteLine($"Valor Liquido: {resgates.Sum(x => x.ValorLiquido):C}");
            }
            
            OpcoesLogado();
        }
        
        static void Resgatar()
        {
            var service = new ProdutoService();
            var resgates = service.Regatar(usuarioLogado.Id);
            if (resgates != null)
            {
                Console.WriteLine($"Valor Investido: {resgates.Sum(x => x.ValorInvestido):C}");
                Console.WriteLine($"Valor Bruto: {resgates.Sum(x => x.ValorBruto):C}");
                Console.WriteLine($"Lucro Bruto: {resgates.Sum(x => x.LucroBruto):C}");
                Console.WriteLine($"Valor IR: {resgates.Sum(x => x.ValorIR):C}");
                Console.WriteLine($"Lucro Liquido: {resgates.Sum(x => x.LucroLiquido):C}");
                Console.WriteLine($"Valor Liquido: {resgates.Sum(x => x.ValorLiquido):C}");

                var serviceUsuario = new UsuarioService();
                var usuario = serviceUsuario.Obter(usuarioLogado.Id);
                if (usuario != null)
                {
                    ExibirUsuario(usuario);
                }
            }
            
            OpcoesLogado();
        }
    }
}
