using System;
using System.Linq;
using static Aliquota.Domain.Helpres.Helpres;
namespace Aliquota.Domain.Models
{
    public class Resgate
    {
        public int ResgateId { get; set; }

        public double Valor { get; set; }

        public DateTime Data { get; set; }

        public decimal Lucro { get; set; }

        public decimal IR { get; set; }

        public int AplicacaoId { get; set; }

        public static Resgate EfetuarResgate(Cliente cliente, DateTime dataResgate){

            // Verifica se o cliente já fez alguma aplicação
            if(cliente.Aplicacoes.Count < 1){
                throw new System.ArgumentException("É necessário que o cliente tenha feito alguma aplicação", "aplicacao");
            }

            // Pega a primeira aplicação que não foi resgatada
            var ultimaAplicacao = cliente.Aplicacoes.Where(q => !q.FoiResgatada).FirstOrDefault();

            // Valida se a data de resgate é menor que a data da aplicação
            if (dataResgate < ultimaAplicacao.Data){
                throw new System.ArgumentException("A data de resgate não pode ser menor que a data de aplicação", "data");
            }

            decimal lucroDaAplicacao = CalcularLucro(ultimaAplicacao.Valor, ultimaAplicacao.Data, dataResgate);

            int anosDeAplicacao = dataResgate.Year - ultimaAplicacao.Data.Year;

            var resgate = new Resgate
            {
                ResgateId = new Random().Next(0,10000),
                Data = dataResgate,
                Lucro = lucroDaAplicacao,
                IR  = CalcularImpostoDeRenda(lucroDaAplicacao, anosDeAplicacao),
                AplicacaoId = ultimaAplicacao.AplicacaoId
            };


            cliente.Resgates.Add(resgate);

            return resgate;
        }
    }
}
