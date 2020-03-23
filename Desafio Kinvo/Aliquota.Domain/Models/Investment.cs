using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aliquota.Domain.Models
{
    public class Investment
    {
        [Key]
        public int id { get; set; }
        public int period { get; set; }

        public string nickname { get; set; }

        public decimal amountBegin { get; set; }
        public decimal gain { get; set; }
        public decimal amount { get; set; }
        public decimal canRecover { get; set; }
        public decimal tax { get; set; }

        public DateTime started { get; set; }
    }
}
