using AliquotaImpostoRenda.Data.Context;
using AliquotaImpostoRenda.Dominio.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AliquotaImpostoRenda.Aplicacao.Interface
{
    public interface IClienteAplicacao
    {
        Task<List<ClienteDTO>> ListarClientes();
        int GravarCliente(string nome);
        ClienteDTO BuscarCliente(string nome);
    }
}
