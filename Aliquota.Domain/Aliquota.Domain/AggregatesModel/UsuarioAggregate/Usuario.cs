using System;
using System.Collections.Generic;
using System.Text;
using Aliquota.Domain.SeedWork;

namespace Aliquota.Domain.AggregatesModel.Usuario
{
    public class Usuario : Entity, IAggregateRoot
    {
        public string nome { get; private set; }

        public Usuario (string nome)
        {
            this.nome = nome;
        }       
    }
}
