using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceSevices;
using Domain.Interfaces.InterfaceConsulta;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppConsulta : InterfaceConsultaApp
    {
        IConsulta _IConsulta;
        IServiceConsulta _IServiceConsulta;
        public AppConsulta(IConsulta IConsulta, IServiceConsulta IServiceConsulta)
        {
            _IConsulta = IConsulta;
            _IServiceConsulta = IServiceConsulta;
        }


        public async Task AddConsulta(Consulta consulta)
        {
            await _IServiceConsulta.AddConsulta(consulta);
        }

        public async Task Add(Consulta Objeto)
        {
            await _IConsulta.Add(Objeto);
        }

        public async Task Delete(Consulta Objeto)
        {
            await _IConsulta.Delete(Objeto);
        }

        public async Task<Consulta> GetEntityById(int Id)
        {
            return await _IConsulta.GetEntityById(Id);
        }

        public async Task<List<Consulta>> List()
        {
           return await _IConsulta.List();
        }
    }
}
