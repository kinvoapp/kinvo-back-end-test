using System;
using Aliquota.Domain.Models;
using System.Threading.Tasks;
using System.Globalization;
using System.Linq;

namespace Aliquota.Application
{
    class Program
    {
        static CultureInfo cultureInfo = new CultureInfo("pt-BR");
        static async Task Main(string[] args)
        {
            string opcao;

            try
            {
                await using var db = new AliquotaRepository();
                // {
                Console.WriteLine("Selecione a opcao desejada:\n1 - Cadastrar Cliente\n2 - Cadastrar Produtos Financeiros\n3 - Detalhar produtos (pelo CPF)\n0 - Sair");
                opcao = Console.ReadLine();
                while (!opcao.Equals("0"))
                {
                    switch (opcao)
                    {
                        case "1":
                            await Program.CadastrarCliente(db);
                            break;
                        case "2":
                            await Program.CadastrarProdutoFinanceiro(db);
                            break;
                        case "3":
                            await Program.ListarProdutosFinanceiros(db);
                            break;
                        default:
                            Console.WriteLine("Opcao nao mapeada!");
                            break;
                    }
                    Console.WriteLine("Selecione a opcao desejada:\n1 - Cadastrar Cliente\n2 - Cadastrar Produtos Financeiros\n3 - Detalhar produtos (pelo CPF)\n0 - Sair");
                    opcao = Console.ReadLine();
                }
                Console.WriteLine("Aplicacao Finalizada");                
            }
            catch (Exception e)
            {
                Console.WriteLine("Ops!! Algo deu errado!");
                Console.WriteLine(e.Message);
            }
        }

        public async static Task CadastrarCliente(AliquotaRepository aliquotaRepo)
        {
            Console.WriteLine("\nInforme o cpf(sem pontuações):");
            string cpf = Console.ReadLine();
            Console.WriteLine("\nInforme o nome:");
            string nome = Console.ReadLine();
            Cliente cliente = new Cliente(Guid.NewGuid(), nome, cpf, null);
            await aliquotaRepo.CriarCliente(cliente);
        }

        public async static Task CadastrarProdutoFinanceiro(AliquotaRepository aliquotaRepo)
        {
            Console.WriteLine("\nInforme o cpf(sem pontuações):");
            string cpf = Console.ReadLine();
            Cliente cliente = await aliquotaRepo.CapturarClientePorCPF(cpf);

            if (cliente != null)
            {
                Console.WriteLine($"Bem-vindo, {cliente.Nome}!");
                Console.WriteLine("\nInforme o valor da aplicacao (ex: 1000.00):");
                string valor = Console.ReadLine();
                decimal valorParse = Decimal.Parse(valor);
                Console.WriteLine("\nInforme a data de aplicacao (formato 'dd/mm/aaaa'): ");
                string dataAplicacao = Console.ReadLine();
                DateTime dataAplicacaoParse = DateTime.Parse(dataAplicacao, Program.cultureInfo);
                Console.WriteLine("\nInforme a data de resgate (formato 'dd/mm/aaaa'): ");
                string dataResgate = Console.ReadLine();
                DateTime dataResgateParse = DateTime.Parse(dataResgate, Program.cultureInfo);
                ProdutoFinanceiro produto = new ProdutoFinanceiro(Guid.NewGuid(), cliente, valorParse, dataAplicacaoParse, dataResgateParse);
                await aliquotaRepo.CriarProdutoFinanceiro(produto);
            }
            else
            {
                Console.WriteLine($"Cliente não existe");
            }
        }

        public async static Task ListarProdutosFinanceiros(AliquotaRepository aliquotaRepo)
        {
            Console.WriteLine("\nInforme o cpf(sem pontuações):");
            string cpf = Console.ReadLine();
            Cliente cliente = await aliquotaRepo.CapturarClientePorCPF(cpf);

            if (cliente != null)
            {
                foreach (var produto in cliente.ProdutosFinanceiros)
                {
                    Console.WriteLine($"\nProduto de valor: {produto.Valor}, aplicado em {produto.DataAplicacao:d} e resgatado em {produto.DataResgate:d}. Imposto: {produto.AliquotaImposto}%");
                }
            }
            else
            {
                Console.WriteLine($"Cliente não existe");
            }
        }
    }
}
