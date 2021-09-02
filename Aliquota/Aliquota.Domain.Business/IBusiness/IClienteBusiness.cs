using Aliquota.Domain.Entities.DTO;
using Aliquota.Domain.Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Business.IBusiness
{
    public interface IClienteBusiness : IBusinessCrudBase<Cliente>
    {
        Task<List<ClienteDto>> GetListGrid();
        void Criar(ClienteDto item);
        Task<ClienteDto> GetItemById(int id);
        void Editar(ClienteDto item);
    }
}
