using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Entities
{
    public class Cliente
    {
        [Key]
        public int ID { get; set; }
        
        public string Nome { get; set; }
    }
}
