using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Aliquiota
{
    [Table("Clientes")]
   public class Cliente
    {
        public Cliente()
        {

        }

        [Key]
        public int IdCliente{get; set;}
        [Display(Name = "Nome:")]
        [Required(ErrorMessage = "Não pode ser Vazio")]
        public string Nome { get; set; }

        [Display(Name = "CPF:")]
        [Required(ErrorMessage = "Não pode ser Vazio")]
        [Column(TypeName = "Numeric(12)")]
        public int Cpf { get; set; }


       


    }
}
