using Aliquiota.Infra.Database;
using Aliquota.Domain;
using Aliquota.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace KinvoApp.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = ConfigurarServicos();

            //var b = a.GetService<Startup>();
            //b.Inicio();

            var aliquotaService = services.GetService<IAliquotaService>();
            var userId = 1;

            //Por questão de coerencia, há a entidade Usuario. Porém, pra simplificar a implementacao, há apenas um usuario.
            aliquotaService.CriarUsuarioSeNaoExiste(userId);

            string opcao = "S";
            do
            {
                try
                {
                    System.Console.WriteLine("Escolha uma opção:");
                    System.Console.WriteLine("1 - Criar Aplicacao");
                    System.Console.WriteLine("2 - Listar Aplicacoes");
                    System.Console.WriteLine("3 - Resgatar Aplicacao");
                    System.Console.WriteLine("4 - Simular Resgate de uma Aplicacao");
                    System.Console.WriteLine("s - Sair");

                    opcao = System.Console.ReadLine();

                    if (opcao.ToUpper() == "S")
                        continue;


                    switch (opcao)
                    {
                        case "1":
                            System.Console.WriteLine("Informe Valor");
                            double valor = double.Parse(System.Console.ReadLine());
                            System.Console.WriteLine("Informe a rentabilidade diaria (Ex: 0.1 = 10%)");
                            double tx = double.Parse(System.Console.ReadLine());

                            aliquotaService.CriarAplicacao(valor, tx, userId);
                            
                            System.Console.WriteLine("-  Aplicacao criada com sucesso!  -");

                            break;
                        case "2":
                            var listaAplicacoes = aliquotaService.ListarAplicacoes(userId);

                            System.Console.WriteLine("-  Aplicacoes  -");
                            foreach (var item in listaAplicacoes)
                            {
                                exibirInfoAplicacao(item);
                            }
                            break;
                        case "3":
                            System.Console.WriteLine("Informe o Numero da aplicacao a ser resgatada");
                            int apId = int.Parse(System.Console.ReadLine());

                            var aplicacao = aliquotaService.ResgatarAplicacao(apId, userId);

                            System.Console.WriteLine("Visualize os dados do resgate");
                            exibirInfoAplicacao(aplicacao);

                            break;
                        case "4":
                            System.Console.WriteLine("Informe o Numero da aplicacao que terá o resgaste simulado");
                            int resgateId = int.Parse(System.Console.ReadLine());                        
                            System.Console.WriteLine("Informe para qual data deseja simular");
                            DateTime dataSimulada = DateTime.Parse(System.Console.ReadLine());

                            var aplicacaoSimulada = aliquotaService.SimularResgateAplicacao(resgateId, userId, dataSimulada);

                            System.Console.WriteLine("Visualize os dados da simulação para a data informada");
                            exibirInfoAplicacao(aplicacaoSimulada);
                            break;
                        default:
                            break;
                    }


                }
                catch (ApplicationException e)
                {
                    System.Console.WriteLine($"Não foi possivel executar a operacao pois: {e.Message}");
                }
                catch (Exception e)
                {
                    System.Console.WriteLine("Algo inesperado ocorreu, tente novamente");
                }
            } while (opcao.ToUpper() != "S");


        }

        public static void exibirInfoAplicacao(Aplicacao aplicacao)
        {
            System.Console.WriteLine($" Aplicacao #{aplicacao.Id}");
            System.Console.WriteLine($"Valor bruto: {aplicacao.ValorBruto}");
            System.Console.WriteLine($"Valor liquido: {aplicacao.ValorLiquido}");
            System.Console.WriteLine($"Valor aplicado: {aplicacao.ValorAplicado}");
            System.Console.WriteLine($"Data da aplicacao: {aplicacao.DataRegistro.ToString("dd/MM/yyyy")}");
            System.Console.WriteLine($"Rentabilidade: {aplicacao.RentabilidadeDiaria*100}%");
            System.Console.WriteLine($"Aliquota IR {aplicacao.AliquotaAplicada*100}%");
            if (aplicacao.DataResgate.HasValue)
                System.Console.WriteLine($"Data do Resgate: {aplicacao.DataResgate.Value.ToString("dd/MM/yyyy")}");
            System.Console.WriteLine($" -----------------------------------------------");

        }

        public static IServiceProvider ConfigurarServicos()
        {
            IServiceCollection collection = new ServiceCollection();
            collection.AddTransient<IRepository, Repository>();
            collection.AddTransient<IAliquotaService, AliquotaService>();
            IServiceProvider serviceProvider = collection.BuildServiceProvider();

            return serviceProvider;
        }
    }

}
