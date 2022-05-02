using Aliquota.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Entities
{
    public class Client
    {
        public Guid ClientID { get; set; }
        public FullName Name { get; set; }
        public CPF CPF { get; set; }
        public Email Email { get; set; }
        public PhoneNumber PhoneNumber { get; set; }

        public Client(Guid id, FullName name, Email email, CPF cpf, PhoneNumber phoneNumber)
        {
            ClientID = id;
            Name = name;
            Email = email;
            CPF = cpf;
            PhoneNumber = phoneNumber;

        }
        
    }
}
