using Alicota.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Alicota.Models
{
    class Produto
    {
        public Produto()
        {
            ID = GerarID.Gerar();
        }
        public int ID { get; set; }
        [Required(ErrorMessage ="O Produto não pode ser em branco")]
        public string NomeProduto { get; set; }
        [Range(1, 99999999999.9, ErrorMessage = "O valor aplicado não pode ser igual a zero")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal ValorAplicado { get; set; }
        [Required(ErrorMessage = "A data da aplição não pode ser em branco")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DataAplicacao { get; set; }
        [Range(1, 99999999999.9, ErrorMessage = "O valor regatado não pode ser igual a zero")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal? ValorResgatado { get; set; }
        [Required(ErrorMessage = "A data do resgate não pode ser em branco")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? DataResgate { get; set; }
    }
}
