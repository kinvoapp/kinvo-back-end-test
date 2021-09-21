using System;
using Aliquota.Domain.Commands.Contracts;
using Aliquota.Domain.Handlers.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Aliquota.Domain.Commands
{
    public class CreateClientCommandResult : ICommandResult
    {
        public CreateClientCommandResult()
        {

        }
        public CreateClientCommandResult(Guid id, string document, string user)
        {
            Id = id;
            Document = document;
            User = user;
        }

        public Guid Id { get; set; }
        public string Document { get; set; }
        public string User { get; set; }

    }
}