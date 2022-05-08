using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Entities
{
    public class Produto {

        [Key]
        public int Id { get; set; }

        private String _nome;
        public String Nome { 
            get { return _nome; }
            set {
                if(value.Length <3)
                {
                    throw new FormatException("Nome do produto deve possuir pelo menos 3 caracteres");
                }
            }}
    }
}