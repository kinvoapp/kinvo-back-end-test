using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Commands {
    public class CreateUserCommand {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [MaxLength(50)]
        [Required]
        public string FullName { get; set; }

        [MinLength(8)]
        [MaxLength(20)]
        [Required]
        public string Password { get; set; }
    }
}