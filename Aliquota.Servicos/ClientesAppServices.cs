using Aliquota.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Servicos
{
    public class ClientesAppServices : BaseAppServices<Guid, Cliente>
    {
        public ClientesAppServices(InfraFactory infraFactory) :base(infraFactory)
        {

        }
    }
}
