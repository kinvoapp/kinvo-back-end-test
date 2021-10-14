using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string  Cpf { get; set; }
        public string Sexo { get; set; }
        public string  Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereço { get; set; }
        public Carteira Carteira { get; set; }
    }
}
