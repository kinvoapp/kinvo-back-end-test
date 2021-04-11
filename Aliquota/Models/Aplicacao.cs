using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Models
{
    public class Aplicacao
    {
        public int Id { get; set; }
        [Required]
        public double valor { get; set; }

        public DateTime dataAplicacao { get; set; }

    }
}
