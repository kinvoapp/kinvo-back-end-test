using System;
using System.Collections.Generic;

namespace Aliquota.Domain.Models
{
    public class Aplicacao
    {
        public int AplicacaoId { get; set; }

        public decimal Valor { get; set; }

        public DateTime Data { get; set; }

        public bool FoiResgatada { get; set; }

        public static Aplicacao EfetuarAplicacao(Cliente cliente, decimal valor)
        {
            if (valor <= 0){
                throw new System.ArgumentException("A aplicação não pode ser igual ou menor que zero", "valor");
            }

            var aplicacao = new Aplicacao
            {
                AplicacaoId = new Random().Next(0,10000),
                Data = DateTime.Now,
                Valor = valor,
                FoiResgatada = false
            };

            cliente.Aplicacoes.Add(aplicacao);

            return aplicacao;
        }
    }
}
