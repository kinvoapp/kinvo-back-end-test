
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Aliquiota
{   
    [Table("Contas")]
    public class Conta
    {
        public Conta()
        {
            Banco = new Banco();
            Cliente = new Cliente();
        }
        [Key]
        public int IdConta { get; set; }


        [Display(Name = "Numero da Conta:")]
        [Required(ErrorMessage = "Não pode ser Vazio")]
        [Column(TypeName = "Numeric(9)")]
        public int NumeroConta { get; set; }

        [Display(Name = "Saldo:")]
        [Required(ErrorMessage = "Não pode ser Vazio")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Saldo { get; set; }

        
        [Display(Name = "Banco:")]
        [Required(ErrorMessage = "Não pode ser Vazio")]
        public Banco Banco { get; set; }

        [Display(Name = "Senha:")]
        [Required(ErrorMessage = "Não pode ser Vazio")]
        public string Senha { get; set; }

        public Cliente Cliente { get; set; }
    }
}
