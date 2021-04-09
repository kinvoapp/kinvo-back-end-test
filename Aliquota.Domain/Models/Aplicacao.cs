using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Models
{
    public class Aplicacao
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double Valor { get; set; }
        public double Rentabilidade_Mes { get; set; }
        public DateTime Data { get; set; }
    }
}