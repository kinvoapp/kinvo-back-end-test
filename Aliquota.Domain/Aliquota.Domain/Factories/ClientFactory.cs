using Aliquota.Domain.Entities;
using Aliquota.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Factories
{
    class ClientFactory
    {
        public Client BuildNewClient(string name, string lastName, string email, string cpf, string phoneNumber)
        {
            Guid clientID = Guid.NewGuid();
            FullName _name = new FullName(name, lastName);
            Email _email = new Email(email);
            CPF _cpf = new CPF(cpf);
            PhoneNumber _phoneNumber = new PhoneNumber(phoneNumber);
            Client client = new Client(clientID, _name, _email, _cpf, _phoneNumber);
            return client;
        }
    }
}
