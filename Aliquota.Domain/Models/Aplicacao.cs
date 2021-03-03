using Aliquota.Domain.Utilitarios;
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
    [Display(Name = "Data de Aplicacao")]
    [DataType(DataType.DateTime)]
    public DateTime DataAplicacao { get; set; }

    [Required]
    [Display(Name = "Data de Resgate")]
    [DateGreaterThan("DataAplicacao")]
    [DataType(DataType.DateTime)]
    public DateTime DataResgate { get; set; }

    [Required]
    [Display(Name = "Quantia Inicial")]
    [DataType(DataType.Currency)]
    [Range(0, 9999999999999999.99, ErrorMessage = "Valor não pode ser negativo")]
    public decimal QuantiaInicial { get; set; }

    [Required]
    [Display(Name = "Quantia Final")]
    [DataType(DataType.Currency)]
    [Range(0, 9999999999999999.99)]
    public decimal QuantiaFinal { get; set; }

    [DataType(DataType.Currency)]
    [Range(0, 9999999999999999.99)]
    public decimal Lucro { get; set; }

    [DataType(DataType.Text)]
    [Range(0, 9999999999999999.99)]
    public decimal Juros { get; set; }

    [Display(Name = "Valor Final")]
    [DataType(DataType.Currency)]
    [Range(0, 9999999999999999.99)]
    public decimal ValorFinalDeduzidoINSS { get; set; }

    //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    //{
    //  if (DataResgate < DataAplicacao)
    //  {
    //    yield return new ValidationResult(
    //        errorMessage: "Data de Aplicacao deve ser anterior a Data de Resgate",
    //        memberNames: new[] { "DataResgate" }
    //   );
    //  }
    //}

  }
}
