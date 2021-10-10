﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.BusinessLogic.Models
{
    public class FinanceProductMove
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }

        [Required]
        public User User{ get; set; }

        [Required]
        public FinanceProduct FinanceProduct { get; set; }

        [Required]
        public decimal Amount{ get; set; }

        [Required]
        public decimal CurrentAmount{ get; set; }

        [Required]
        public decimal Price{ get; set; }
        public DateTime DateTime { get; set; }

    }
}
