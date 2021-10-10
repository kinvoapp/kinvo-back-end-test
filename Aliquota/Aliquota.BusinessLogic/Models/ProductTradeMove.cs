using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.BusinessLogic.Models
{
    public class ProductTradeMove
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public User User { get; set; }


        [Required]
        public FinanceProductMove FistFinanceProductMove { get; set; }

        [Required]
        public FinanceProductMove SecondFinanceProductMove { get; set; }

        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
    }
}
