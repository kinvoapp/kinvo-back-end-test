using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Models
{
    public class Investimento
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Informe o nome!")]
        [StringLength(50, MinimumLength =3)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o Valor!")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Range(1.00,1000000.00, ErrorMessage ="Valor deve ser maior que zero!")]
        public double Valor_inicio { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public double Valor_final { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        public DateTime Dt_entrada { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        public DateTime Dt_saida { get; set; }       
    }
}
