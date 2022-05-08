using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Entities
{
    public enum Tipo 
    {
        Aplicacao,
        Resgate
    }

    public class Movimentacao 
    {

        public Movimentacao(DateTime dataMovimentacao, double valor, Tipo tipo)
        {
            if( valor <= 0)
            {
                throw new ArgumentException("A aplicação/resgate não pode ser igual ou menor que zero.");
            }

            this.DataMovimentacao = dataMovimentacao;
            this.Valor = valor;
            this.Tipo = tipo;
        }

        [Key]
        public int Id { get; set; }

        public DateTime DataMovimentacao;
        public double Valor;

        // Aplicacao ou Resgate
        public Tipo Tipo;

    }
}