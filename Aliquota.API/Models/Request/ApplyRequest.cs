using System.ComponentModel.DataAnnotations;

namespace Aliquota.API.Models.Request
{
    public class ApplyRequest
    {
        [Required]
        public decimal ApplicationValue { get; set; }

        [Required]
        public string ClientCPF { get; set; }
    }
}