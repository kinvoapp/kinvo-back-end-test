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

        [Key]
        public int Id { get; set; }

        public DateTime DataMovimentacao;
        public double Valor;

        // Aplicacao ou Resgate
        public Tipo Tipo;

        public Guid Identificador { get; set; }





    }
}