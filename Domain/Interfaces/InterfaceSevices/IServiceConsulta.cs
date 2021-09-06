using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceSevices
{
    public interface IServiceConsulta
    {
        Task AddConsulta(Consulta consulta);

    }
}
