using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Aliquiota
{
    [Table("Produtos")]
    public class Produto
    {
        public Produto()
        {
            Banco = new Banco();
        }

        [Key]
        public int IdProduto { get; set; }

        [Required(ErrorMessage = "Não pode ser Vazio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Não pode ser Vazio")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Não pode ser Vazio")]
        [Column(TypeName = "decimal(4,2)")]
        public decimal Rendimento { get; set; }

        [Required(ErrorMessage = "Não pode ser Vazio")]
        public Banco Banco { get; set; }

        [Required(ErrorMessage = "Não pode ser Vazio")]
        public int Tempo_Rendimento_Dias { get; set; }


        [Required(ErrorMessage = "Não pode ser Vazio")]
        [Column(TypeName = "decimal(4,2)")]
        public decimal Taxa_Menor_IR { get; set; }

        [Required(ErrorMessage = "Não pode ser Vazio")]
        [Column(TypeName = "decimal(4,2)")]
        public decimal Taxa_Maior_IR { get; set; }



        [Required(ErrorMessage = "Não pode ser Vazio")]
        [Column(TypeName = "decimal(4,2)")]
        public decimal Taxa_Entre_IR { get; set; }

        [Required(ErrorMessage = "Não pode ser Vazio")]
        public int Ano_Menor_IR { get; set; }

        [Required(ErrorMessage = "Não pode ser Vazio")]
        public int Ano_Maior_IR { get; set; }

    }
}
