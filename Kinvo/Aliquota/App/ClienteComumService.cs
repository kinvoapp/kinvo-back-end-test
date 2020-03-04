using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aliquota.App.Interfaces;
using Aliquota.Domain;

namespace Aliquota.App
{
   public  class ClienteComumService:ClienteServiceTemplate
    {
        public ClienteComumService(Cliente cliente) : base(cliente)
        {
        }

        /// <summary>
        /// Realizar Resgate
        /// </summary>
        /// <param name="valorResgate"></param>
        /// <param name="produtoId"></param>
        /// <param name="dataResgate"></param>
        /// <returns></returns>
        public override InformacaoFiscal Resgatar(decimal valorResgate, int produtoId, DateTime dataResgate)
        {
            //Aqui pode-se aplicar uma condição diferenciada para um determinado cliente especifico

            if (Produtos == null)
                throw new InvalidOperationException("Não foram encontrados produtos para o cliente");
            if (Produtos.All(n => n.Id != produtoId))
                throw new InvalidOperationException("Produto não encontrado");
            var produto = Produtos.Single(n => n.Id == produtoId);
            if (produto.Saldo == 0 || produto.Saldo < valorResgate)
                throw new InvalidOperationException("Saldo Insuficiente");
            if (dataResgate.CompareTo(produto.Data) < 0)
                throw new InvalidOperationException("A data de resgate não pode ser menor que a data de aplicação");


            var saldoAtual = produto.Saldo;
            //Calcular rendimento em cima do valor sacado
            var rendimentoJuros = CalcularRedimento(produto, valorResgate, dataResgate);
            var aliquotaIr = ObterAliquota(produto.Data, dataResgate);
            var totalBruto = CalcularRedimento(produto, saldoAtual, dataResgate) + saldoAtual;
            var valorRetido = rendimentoJuros * (aliquotaIr / 100);

            var saldo = totalBruto - valorResgate - valorRetido;
            //Atualiza saldo 
            produto.Saldo = saldo;

            return new InformacaoFiscal
            {
                RedimentoAplicacao = rendimentoJuros,
                Aliquota = aliquotaIr,
                ValorRetido = valorRetido,
                Saque = valorResgate,
                Produto = produto,

            };
        }

        /// <summary>
        ///     Calcular Rendimento
        /// </summary>
        /// <param name="produto"></param>
        /// <param name="DataResgate"></param>
        /// <returns></returns>
        private decimal CalcularRedimento(Produto produto, decimal montante, DateTime DataResgate)
        {
            var anoAplicacao = produto.Data.Year;
            var anoResgate = DataResgate.Year;
            var periodoAno = anoResgate - anoAplicacao;
            return montante * (produto.PercentualRedimento / 100) * periodoAno;
        }

        /// <summary>
        ///     Obter Aliquota do IR
        /// </summary>
        /// <param name="dataAplicacao"></param>
        /// <returns></returns>
        private decimal ObterAliquota(DateTime dataAplicacao, DateTime dataResgate)
        {
            //Data Resgate
            var anoResgate = dataResgate.Year;
            var anoAplicacao = dataAplicacao.Year;
            var periodoAno = anoResgate - anoAplicacao;
            if (periodoAno == 1) return 22.5m;
            if (periodoAno >= 1 && periodoAno <= 2) return 18.5m;
            return 15;
        }
    }
}
