using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Models
{
    public class Aplicacoes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double Valor { get; set; }
        public double Rentabilidade_Mes { get; set; }
        public DateTime Data { get; set; }
        public bool Resgatada { get; set; }
        public List<Historicos> Hisotricos { get; set; }
    }
}