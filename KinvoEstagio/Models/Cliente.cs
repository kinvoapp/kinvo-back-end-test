using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KinvoEstagio.Models
{
    public class Cliente
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public float Investimento { get; set; }
        [Required]
        [DisplayName("Data")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Tempo { get; set; }
        DateTime hoje = DateTime.Today;
        public float Imposto { get; set; }
        [DataType(DataType.Currency)]
        public float Rendimento { get; set; }
    }
}
