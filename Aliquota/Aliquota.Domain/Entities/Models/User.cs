using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Entities.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(30), MinLength(5)]
        public string Name{ get; set; }
        [Required, MaxLength(30), MinLength(5)]
        public string Email{ get; set; }
        [Required, MaxLength(30), MinLength(5)]
        public string Password { get; set; }
#nullable enable
        [MaxLength(30), MinLength(3)]
        public string? Phone{ get; set; }
        [MaxLength(30), MinLength(3)]
        public string? PhoneNumber{ get; set; }
#nullable disable

        public List<FinanceProductMove> FinanceProductMoves { get; set; }
        public List<FinanceProductWallet> FinanceProductWallets{ get; set; }
    }
}
