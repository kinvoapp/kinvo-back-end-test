using System;
using System.Globalization;

namespace Aliquota.Domain
{


   public class CalculaAliquota
	{

		static Aplicacao[] Aplicacoes = new Aplicacao[10];
		static int codigoAtual = 0;
		static NumberFormatInfo nfi = new CultureInfo("pt-BR", false).NumberFormat;
		static CultureInfo culture = new CultureInfo("pt-BR", false);
		static Aplicacao ap;

		static void Main(String[] args)
			{

				CalculaAliquota p = new CalculaAliquota();
				p.Run();
			}

		private int Run()
		{
			{
				int opcaoLida = -1;

				while (opcaoLida != 0)
				{
					Console.WriteLine("Escolha a opçao:");
					opcaoLida = ExibeMenu();
					lerOpcao(opcaoLida);

				}

				return opcaoLida;

			}


			static Boolean cadastrar(String nomeCliente, Decimal valorAplicacao, String dataInicial )
		{
			Boolean resultado = true;

			try
			{
		 
			
					if (valorAplicacao <= 0)
					{
						Console.WriteLine("O valor da Aplicação não pode ser menor ou igual a 0.");
						resultado = false;
					}
					else
					{
						Aplicacoes[codigoAtual] = new Aplicacao().Criar(codigoAtual, nomeCliente, valorAplicacao, dataInicial);
						codigoAtual++;
					}
				}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
				resultado = false;
			}



			return resultado;

		}



static void ExibeAplicacoes()
			{

				Console.WriteLine("Codigo |      Nome         |  Valor Aplicado    |    Data de Adesão");
				Console.WriteLine("--------------------------------------------------------------------------");
				for (int i = 0; i <= Aplicacoes.Length - 1; i++)
				{

					Aplicacao Ap = Aplicacoes[i];



					if (Ap != null)
					{

						Console.WriteLine($" {Ap.GetCodigo()}        " +
										  $"{Ap.GetNomeCliente()}               " +
										  $" {Ap.GetValor().ToString("C", nfi)}                     " +
										  $" {Ap.GetDataInicial()}");
					}


				}


			}

			static int ExibeMenu()
		{
			int opcao = 0;
			Console.WriteLine("1 - Nova Aplicação ");
			Console.WriteLine("2 - Consultar Aplicações ");
			if (Aplicacoes.Length != 0)
			{
				Console.WriteLine("3 - Resgatar Aplicação");
			}

			opcao = int.Parse(Console.ReadLine());

			Console.WriteLine($"Voçê escolheu: {opcao}");

			return opcao;
		}

		static void lerOpcao(int opcaoSelecionada)
		{

			switch (opcaoSelecionada)
			{

				case (1):
						
						Console.WriteLine("Informe seu nome:");
						String nomeCliente = Console.ReadLine();

						Console.WriteLine("Informe o valor:");
						Decimal valorAplicacao = Decimal.Parse(Console.ReadLine());

						Console.WriteLine("Informe a data inicial (Ex:dd/mm/AAAA):");
						String dataInicial = Console.ReadLine();
											   
						if (!cadastrar(nomeCliente, valorAplicacao, dataInicial))
					{
						Console.WriteLine("Não foi possível cadastrar..");
					}

					else
					{
						Console.WriteLine("Cadastrado com sucesso..");
					}

					break;


				case (2):

						ExibeAplicacoes();

					break;
					
				case (3):
				  
					Console.WriteLine("Informe o Codigo da Aplicação:");
					int codigoLido = int.Parse(Console.ReadLine());
					Console.WriteLine("Informe a data de retirada da Aplicação (Ex:DD/MM/AAAA):");
					String dataFinal= Console.ReadLine();
					ap = Aplicacoes[codigoLido];
						if (!ap.Resgatar(dataFinal, ap))
					{
						Console.WriteLine("Não foi possível resgatar..");
					}

					else
					{
						Console.WriteLine("Resgatado com sucesso..");
					}
					break;


					   

			}
		   

			}



	   

		   
		}
	}
}
