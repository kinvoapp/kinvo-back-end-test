using AliquotaImpostoRenda.Data.Context;
using AliquotaImpostoRenda.Dominio.DTO;
using AliquotaImpostoRenda.Dominio.Entidades;
using System.Collections.Generic;

namespace AliquotaImpostoRenda.Dados.Interface
{
    public interface IClienteRepositorio
    {
        int Salvar(Cliente cliente);
        List<ClienteDTO> ListarTodos();
        ClienteDTO BuscarCliente(string nome);
    }
}
