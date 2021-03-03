using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aliquota.Domain
{
  public class Aplicacao
  {
    [Key]
    public int Id { get; set; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime DataAplicacao { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime DataResgate { get; set; }

    [Required]
    [DataType(DataType.Currency)]
    [Range(0, 9999999999999999.99, ErrorMessage = "Valor não pode ser negativo")]
    public decimal QuantiaInicial { get; set; }

    [Required]
    [DataType(DataType.Currency)]
    [Range(0, 9999999999999999.99)]
    public decimal QuantiaFinal { get; set; }

    [DataType(DataType.Currency)]
    [Range(0, 9999999999999999.99)]
    public decimal Lucro { get; set; }

    [DataType(DataType.Currency)]
    [Range(0, 9999999999999999.99)]
    public decimal Juros { get; set; }

    [DataType(DataType.Currency)]
    [Range(0, 9999999999999999.99)]
    public decimal ValorFinalDeduzidoINSS { get; set; }


    //public Aplicacao(DateTime dataAplicacao, decimal quantia)
    //{
    //  this.dataAplicacao = dataAplicacao;
    //  this.quantia = quantia;
    //}

  }
}
