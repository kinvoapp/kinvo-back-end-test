using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aliquota.Data.Entity
{
    [Table("client")]
    public class Client
    {
        [Key]
        [Column("id")]
        public long ClientId { get; set; }

        [Column("client_cpf")]
        public string CPF { get; set; }
    }
}