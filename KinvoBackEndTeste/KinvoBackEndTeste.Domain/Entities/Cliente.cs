using System;

namespace KinvoBackEndTeste.Domain.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }

        public override string ToString()
        {
            return Nome + " " + Sobrenome;
        }
    }
}
