
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Models
{
    public class Investimento
    {
        //[Key]
        //[Required]
        /*[Required(ErrorMessage = "O campo é obrigatório")]*/
        public int Id {get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public string Cliente { get; set; }

        [Required(ErrorMessage ="O campo é obrigatório")]
        [Range (0.0001 , 1000000000000000000, ErrorMessage = "O lucro deve ser maior do que 0")]
        public double Lucro { get; set; }

        public int TempoEmDias { get; set; }
        public int TempoEmAnos { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public DateTime DataDeInicio { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório")]
        public DateTime DataDeResgate { get; set; }
    }
}
