using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain
{
    public class Cliente
    {
        private string nome;
        private int cpf;
        public List<float> valorAplicado, valorResgatado;

        public Cliente()
        { }

        public Cliente(string nome, int cpf)
        {
            this.nome = nome;
            this.cpf = cpf;
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public int Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }
    }
}
