using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Commands {
    public class CreateUserCommand {
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(50)]
        public string FullName { get; set; }

        [MinLength(8)]
        [MaxLength(20)]
        public string Password { get; set; }
    }
}