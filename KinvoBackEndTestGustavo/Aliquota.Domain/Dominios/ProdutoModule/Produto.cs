using Aliquota.Domain.Dominios.Shared;
using System;

namespace Aliquota.Domain.Dominios.ProdutoModule
{
    public class Produto : EntidadeBase
    {
        public string Nome { get; set; }

        public Produto(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public override string Validar()
        {
            string resultado = "";

            if (String.IsNullOrEmpty(Nome))
                resultado += "O nome do produto não poder ser nulo\n";
            if (String.IsNullOrEmpty(resultado))
                resultado = "VALIDO";

            return resultado;
        }
    }
}
