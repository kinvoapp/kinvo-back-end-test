using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.BusinessLogic.Models
{
    public class FinanceProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(60), MinLength(3)]
        public string Name { get; set; }
        public List<FinanceProductMove> FinanceProductMoves { get; set; }
        public List<FinanceProductWallet> FinanceProductWallets { get; set; }

    }
}
