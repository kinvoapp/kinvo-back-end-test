using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Models
{
    public class Aplicacao
    {
        public int Id { get; set; }
        [Required]

        [DisplayName("Valor")]
        public double valor { get; set; }

        [DisplayName("Data Aplicação")]
        public String dataAplicacao { get; set; }

    }
}
