using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Models
{
    public class BaseModel
    {
        [Key]
        [Required]
        public int Id { get; protected set; }
    }
}
