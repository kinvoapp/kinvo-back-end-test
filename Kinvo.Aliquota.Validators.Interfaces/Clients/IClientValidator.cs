using Kinvo.Aliquota.Domain.Entities.Clients;
using Kinvo.Aliquota.Models.Clients;
using Kinvo.Aliquota.Validators.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Validators.Interfaces.Clients
{
    public interface IClientValidator : IBaseValidator<Client, ClientRequest>
    {
    }
}
