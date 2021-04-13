using System.ComponentModel.DataAnnotations;

namespace Aliquota.API.Models.Request
{
    public class CreateClientRequest
    {
        [Required]
        public string CPF { get; set; }
    }
}