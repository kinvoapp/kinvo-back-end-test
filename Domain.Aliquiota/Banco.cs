
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Aliquiota
{
    [Table("Bancos")]
    public class Banco
    {
        public Banco()
        {
            
        }

        [Key]
        public int idBanco { get; set; }

        [Display(Name = "Nome do Banco:")]
        [Required(ErrorMessage = "Não pode ser Vazio")]
        public string Nome { get; set; }

        [Display(Name = "Numero do Banco:")]
        [Required(ErrorMessage = "Não pode ser Vazio")]
        public int Numero { get; set; }
    }
}
