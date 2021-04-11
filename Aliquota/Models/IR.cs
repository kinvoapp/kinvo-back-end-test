using Aliquota.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Models
{
    public class IR
    {
        public int Id { get; set; }
        [Required]

        [DisplayName("Valor")]
        public double valor { get; set; }

        [DisplayName("Data Resgate")]
        public String dataResgate { get; set; }

        [DisplayName("Data Aplicação")]
        public String dataAplicacao { get; set; }

        [DisplayName("IR")]
        public double ir { get; set; }

        [DisplayName("Lucro")]
        public double lucro { get; set; }

        [DisplayName("Aliquota")]
        public double aliquota { get; set; }
    }
}
