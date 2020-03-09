using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aliquota.Domain.Entities
{

    [Table("Cliente")]
    public class Cliente
    {
        [Key, Column("ID")]
        [Display (Description ="Código")]
        public int ID { get; set; }

        [Column("Nome")]
        [Display(Description = "Nome")]
        public string Nome { get; set; }
    }
}
