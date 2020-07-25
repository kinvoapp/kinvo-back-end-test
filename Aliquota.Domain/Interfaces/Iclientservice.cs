using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Interfaces
{
    public interface Iclientservice
    {
        void CreateClient(client client);
        client SearchClient(client client);
    }
}
