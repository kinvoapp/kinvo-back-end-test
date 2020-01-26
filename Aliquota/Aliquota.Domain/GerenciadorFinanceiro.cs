using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain
{
	public class GerenciadorFinanceiro
	{
		private readonly ServicoCliente _servicoCliente;
		private readonly ServicoProdutoFinanceiro _servicoProdutoFinanceiro;
		private readonly ServicoAplicacao _servicoAplicacao;

		public GerenciadorFinanceiro(
			ServicoCliente servicoCliente, 
			ServicoProdutoFinanceiro servicoProdutoFinanceiro,
			ServicoAplicacao servicoAplicacao)
		{
			_servicoCliente = servicoCliente;
			_servicoProdutoFinanceiro = servicoProdutoFinanceiro;
			_servicoAplicacao = servicoAplicacao;
		}

		/// <summary>
		/// Realiza uma aplicação em um determinado produto financeiro para um cliente
		/// Cria uma aplicação ou atualiza uma existente
		/// </summary>
		/// <param name="cliente">Cliente solicitante</param>
		/// <param name="produto">Produto Financeiro escolhido</param>
		/// <param name="valor">Valor da aplicação</param>
		public void Investir(Cliente cliente, ProdutoFinanceiro produto, decimal valor)
		{
			Aplicacao aplicacao = _servicoAplicacao.BuscaPorClienteProdutoFinanceiro(cliente, produto);

			if (aplicacao == null)
				_servicoAplicacao.Adicionar(valor, cliente, produto);
			else
				_servicoAplicacao.Atualizar(valor, cliente, produto);
		}

		/// <summary>
		/// Realiza a retirada de todo o dinheiro investido em uma aplicação
		/// </summary>
		/// <param name="cliente">Cliente solicitante</param>
		/// <param name="produto">Produto Financeiro que contém a aplicação</param>
		/// <param name="dataResgate">Data que será realizado o resgate</param>
		/// <param name="rendimentoPercentualAno">
		/// Taxa média percentual anual de rendimento da aplicação.
		/// Exemplo: 12% a.a (ao ano)
		/// </param>
		/// <returns>
		/// Um dicionário contendo o valorBruto, o imposto pago e o valorLiquido da aplicação
		/// </returns>
		public Dictionary<string, decimal> Resgatar(Cliente cliente, ProdutoFinanceiro produto, DateTime dataResgate, decimal rendimentoPercentualAno)
		{
			// Buscar a aplicação do cliente
			Aplicacao aplicacao = _servicoAplicacao.BuscaPorClienteProdutoFinanceiro(cliente, produto);

			if (aplicacao == null)
				throw new Exception("A aplicação não foi encontrada.");

			// obter o valor da aplicação
			decimal valorTotalResgate = aplicacao.Valor;
			DateTime dataAplicacao = aplicacao.DataInicial;

			if (dataResgate < dataAplicacao)
				throw new Exception("A data de resgate precisa ser após a data de aplicação");

			TimeSpan duracaoAplicacao = dataResgate - dataAplicacao;
			decimal lucro = CalculaLucro(valorTotalResgate, rendimentoPercentualAno, duracaoAplicacao);

			// calcular imposto
			decimal imposto = CalculaIR(lucro, duracaoAplicacao);

			// construir resultado
			Dictionary<string, decimal> resultado = new Dictionary<string, decimal>();
			resultado.Add("valorBruto", valorTotalResgate + lucro);
			resultado.Add("imposto", imposto);
			resultado.Add("valorLiquido", valorTotalResgate + lucro - imposto);

			// remover a aplicação
			_servicoAplicacao.Remover(aplicacao);

			return resultado; 
		}

		private decimal CalculaIR(decimal lucro, TimeSpan duracaoAplicacao)
		{
			if (lucro <= 0)
				return 0;

			if (duracaoAplicacao.Days <= 365)
				return 0.225m * lucro;
			else if (duracaoAplicacao.Days > 365 && duracaoAplicacao.Days <= 365 * 2)
				return 0.185m * lucro;
			else 
				return 0.15m * lucro;
		}

		private decimal CalculaLucro(decimal valoBrutoResgate, decimal rendimentoPercentagemAoAno, TimeSpan duracao)
		{
			double rendimentoDecimal = (double)(rendimentoPercentagemAoAno / 100); // 112,5% -> 0,125
			double fatorDiarioDeRendimento = Math.Pow(1 + rendimentoDecimal, 1f / 365f); // 1,125 ao ano -> 1,00032458 ao dia

			double valorBrutoResgateComRendimento = Math.Pow(fatorDiarioDeRendimento, duracao.TotalDays) * (double)valoBrutoResgate;

			return (decimal)valorBrutoResgateComRendimento - valoBrutoResgate;
		}
	}
}
