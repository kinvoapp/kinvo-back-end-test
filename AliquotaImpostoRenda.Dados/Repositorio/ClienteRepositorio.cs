using AliquotaImpostoRenda.Dados.Interface;
using AliquotaImpostoRenda.Data.Context;
using AliquotaImpostoRenda.Dominio.DTO;
using AliquotaImpostoRenda.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace AliquotaImpostoRenda.Dados.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        public ClienteRepositorio()
        {}

        public int Salvar(Cliente cliente)
        {
            using (var db = new AliquotaImpostoRendaContext())
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
            }
            return cliente.Id;
        }

        public List<ClienteDTO> ListarTodos()
        {
            using (var db = new AliquotaImpostoRendaContext())
            {
                return db.Clientes.Select(c => new ClienteDTO
                {
                    Nome = c.Nome,
                    Id = c.Id,
                    Createad = c.Createad
                }).ToList();
            }
        }

        public ClienteDTO BuscarCliente(string nome)
        {
            using (var db = new AliquotaImpostoRendaContext())
            {
                return db.Clientes.Where(c => c.Nome.ToLower() == nome.ToLower()).Select(c => new ClienteDTO
                {
                    Id = c.Id,
                    Nome = c.Nome
                }).FirstOrDefault();
            }
        }
    }
}
