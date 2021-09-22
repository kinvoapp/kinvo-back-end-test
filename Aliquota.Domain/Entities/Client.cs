using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Notifications;
using Flunt.Validations;

namespace Aliquota.Domain.Entities
{
    public class Client : Entity
    {
        public Client(string user, string document)
        {
            User = user;
            Document = document;
            Exists = true;
            AddNotifications(new Contract().Requires()
            .HasMinLen(User, 3, "Name", "O nome deve conter ao mínimo 3 caracteres !")
            .HasMaxLen(User, 25, "Name", "O nome deve conter ao máximo 25 caracteres !")
            .IsNotNullOrEmpty(User, "Name", "O Nome do cliente não pode ser vazio !")
            .HasLen(Document, 11, "Document", "CPF inválido !")
            .IsTrue(Exists, "ClientExistis", "Não existe um cliente !"));
        }

        public string Document { get; private set; }
        public string User { get; private set; }
        public double TaxValue { get; private set; }
        public bool Exists { get; private set; }
        public bool ClientExist()
        {
            AddNotifications(new Contract().Requires()
            .IsTrue(Exists, "ClientExists", "É necessário criar um cliente primeiro !"));
            return Exists;
        }
        public override string ToString()
        {
            return $"{User}";
        }

    }
}
