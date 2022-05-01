using Aliquota.Domain.AplicacaoModule;
using Aliquota.Domain.Shared;
using System;
using System.Collections.Generic;

namespace Aliquota.Domain.ProdutoModule
{
    public class Produto : EntidadeBase
    {
        public string Nome { get; set; }
        public List<Aplicacao> Aplicacoes { get; set; }

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

        public override string ToString()
        {
            return Nome;
        }
    }
}
