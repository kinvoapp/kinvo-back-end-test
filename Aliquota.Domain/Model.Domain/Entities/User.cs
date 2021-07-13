

namespace Model.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Cpf { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public double Capital { get; set; }
    }
}
