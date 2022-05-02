using FluentValidation;
using Kinvo.Aliquota.Domain.Entities.Clients;
using Kinvo.Aliquota.Models.Clients;
using Kinvo.Aliquota.Validators.Interfaces.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Validators.Clients
{
    public class ClientValidator : AbstractValidator<ClientRequest>, IClientValidator
    {
        public ClientValidator()
        {
        }

        private void GeneralValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required").NotNull().WithMessage("Name is required")
                .MaximumLength(200).WithMessage("Maximum lengh must be 200 caracteres");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("Cpf is required").NotNull().WithMessage("Cpf is required");
        }

        public async Task ValidateCreation(ClientRequest request)
        {
            GeneralValidator();
        }

        public async Task<Client> ValidateEdit(Guid? uuid, ClientRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<Client> ValidateRemove(Guid? uuid)
        {
            throw new NotImplementedException();
        }

    }
}
