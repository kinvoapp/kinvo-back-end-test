using System;
using System.Linq;

namespace Aliquota.Domain.Models
{
    public class Transacao
    {
        public int TransacaoId { get; set; }

        public int TipoTransacao { get; set; }

        public double Valor { get; set; }

        public DateTime Data { get; set; }

        public int? AplicacaoResgatada { get; set; }

        public decimal? IR { get; set; }

        public enum TiposDeTrasacoes
        {
            Aplicacao,
            Resgate
        }

        public void Aplicar(Cliente cliente, double valor){

            if (valor <= 0){
                throw new System.ArgumentException("A aplicação não pode ser igual ou menor que zero", "valor");
            }

            var transacao = new Transacao
            {
                TransacaoId = 123,
                Data = DateTime.Now,
                Valor = valor,
                TipoTransacao = (int)TiposDeTrasacoes.Aplicacao
            };

            cliente.Transacoes.Add(transacao);
        }

        public void Resgatar(Cliente cliente){

            var ultimaAplicacao = cliente.Transacoes
                                        .Where(q => q.TipoTransacao == (int)TiposDeTrasacoes.Aplicacao)
                                        .FirstOrDefault();

            if (DateTime.Now < ultimaAplicacao.Data){
                throw new System.ArgumentException("A data de resgate não pode ser menor que a data de aplicação", "data");
            }

            var transacao = new Transacao
            {
                TransacaoId = 123,
                Data = DateTime.Now,
                Valor = ultimaAplicacao.Valor,
                TipoTransacao = (int)TiposDeTrasacoes.Aplicacao,
                AplicacaoResgatada = ultimaAplicacao.TransacaoId
                //IR  =  Calcular
            };

            cliente.Transacoes.Add(transacao);
        }
    }
}
