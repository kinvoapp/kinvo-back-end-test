using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Aliquiota
{
    [Table("Investimentos")]
    public class Investimento
    {
        public Investimento()
        {
            Produto = new Produto();
            Conta = new Conta();
            DataAplicacao = DateTime.Now;
        }
        [Key]
        public int IdInvestimento {get;set;}

        

        [Display(Name = "Valor:")]
        [Required(ErrorMessage = "Não pode ser Vazio")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal ValorInvestido { get; set; }

        
        [Column(TypeName = "decimal(8,2)")]
        public decimal ValorResgatadoBruto { get; set; }

        
        [Column(TypeName = "decimal(8,2)")]
        public decimal ValorResgatadoLiquido { get; set; }

        
        [Column(TypeName = "decimal(8,2)")]
        public decimal ValorRecolhidoIR { get; set; }

        public DateTime DataAplicacao { get; set; }

        
        public DateTime DataResgate { get; set; }


        public Produto Produto { get; set; }
        public Conta Conta { get; set; }

    }
}
