using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces
{
    public interface InterfaceConsultaApp : InterfaceGenericApp<Consulta>
    {
        Task AddConsulta(Consulta consulta);
    }
}
