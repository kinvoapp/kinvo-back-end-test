using Aliquota.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Models
{
    public class IR
    {
        public int Id { get; set; }
        [Required]
        public double valor { get; set; }

        public String dataResgate { get; set; }

        public String dataAplicacao { get; set; }

        public double ir { get; set; }

        public double lucro { get; set; }

        public double aliquota { get; set; }
    }
}
