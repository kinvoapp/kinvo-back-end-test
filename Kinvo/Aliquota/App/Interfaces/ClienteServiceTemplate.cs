// ===================================================================
//  Autor: Valnei Filho
//  E-mail: v_marinpietri@yahoo.com.br, 719946-7636
//  Data Criação: 04/03/2020
// ===================================================================


using System;
using System.Collections.Generic;
using System.Linq;
using Aliquota.CrossCuting;
using Aliquota.Domain;

namespace Aliquota.App.Interfaces
{
    public abstract class ClienteServiceTemplate
    {
        #region Propriedades

        public List<Produto> Produtos { get; private set; }

        public Cliente Cliente { get;} 


        #endregion

        public ClienteServiceTemplate(Cliente cliente)
        {
            Cliente = cliente;
            Produtos = new List<Produto>();
        }

        /// <summary>
        /// Realizar Aplicação
        /// </summary>
        /// <param name="produto"></param>
        public void Aplicar(List<Produto> produto)
        {
            var list = new List<Produto>();
            int i = 1;
            produto.ForEach(item =>
            {
                if (item.Saldo <= 0)
                    throw new InvalidOperationException("A aplicação neste produto não pode ser igual ou menor que zero");
                item.Id = i;

                list.Add(item);
                i++;
            });
            Produtos = list;
        }

        public void Aplicar(Produto produto)
        {

            if (produto.Saldo<=0)
                throw new InvalidOperationException("A aplicação neste produto não pode ser igual ou menor que zero");
            var id = Produtos.Count + 1;

            produto.Id = id;
            Produtos.Add(produto);
        }

         

        public virtual InformacaoFiscal Resgatar(decimal valorResgate, int produtoId, DateTime dataResgate)
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


            var redimento = CalcularRedimento(produto, produto.Saldo, dataResgate);
            var aliquotaIr = ObterAliquota(produto.Data, dataResgate);
            var valorRetido = redimento * (aliquotaIr / 100);
            var saldo = (redimento + produto.Saldo) - (valorRetido + valorResgate);
            var saldo2 = produto.Saldo - valorRetido;
            if (valorResgate >= produto.Saldo)
            {
                throw new InvalidOperationException($"Saldo insuficiente para resgate, valor disponível após desconto de IR {saldo2}");
            }

            //Atualiza saldo 
            produto.Saldo = saldo;

            return new InformacaoFiscal
            {
                    RedimentoAplicacao = redimento.Arredondar(2),
                    Aliquota = aliquotaIr.Arredondar(2),
                    ValorRetido = valorRetido.Arredondar(2),
                    Saque = valorResgate.Arredondar(2),
                    Produto = produto


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