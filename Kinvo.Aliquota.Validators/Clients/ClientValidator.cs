using FluentValidation;
using Kinvo.Aliquota.Domain.Entities.Clients;
using Kinvo.Aliquota.Models.Clients;
using Kinvo.Aliquota.Validators.Interfaces.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kinvo.Aliquota.Domain.Database.Interfaces.Clients;

namespace Kinvo.Aliquota.Validators.Clients
{
    public class ClientValidator : AbstractValidator<ClientRequest>, IClientValidator
    {
        private readonly IClientRepository _clientRepository;
        public ClientValidator(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
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
        
        public async Task<Client> ValidateUuid(Guid? uuid)
        {
            if (!uuid.HasValue)
            {
                throw new ArgumentException("Uuid is required");
                return null;
            }

            var obj = await _clientRepository.FindAsync(uuid.Value);

            return obj;

        }

    }
}
