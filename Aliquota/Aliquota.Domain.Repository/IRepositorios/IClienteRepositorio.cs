using Aliquota.Domain.Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Repository.IRepositorios
{
    public interface IClienteRepositorio : IBaseRepositorio<Cliente>
    {
        Task<Cliente> GetClienteComProduto(int id);
    }
}
