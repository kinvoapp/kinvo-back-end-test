using System;
namespace src.Models
{
    public class Ativo
    {
        public int Id { get; set; }

        //Deve ser um model de Pessoa Juridica
        public string NomeAtivo { get; set; }

        //Deve ser um model de Pessoa Juridica
        public int Cnpj { get; set; }

        public DateTime DataEmissao { get; set; }
    }
}
