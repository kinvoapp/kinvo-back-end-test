using Domain.Aliquiota;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Aliquiota
{
    public class ClienteDao : IRepository<Cliente>
    {
        private readonly Context ctx;
        public ClienteDao(Context context)
        {
            ctx = context;
        }

        public Cliente BuscaCpf(Cliente c)
        {
            return ctx.Clientes.FirstOrDefault(x => x.Cpf.Equals(c.Cpf));
        }

        public Cliente BuscaNome(Cliente c)
        {
            return ctx.Clientes.FirstOrDefault(x => x.Nome.Equals(c.Nome));
        }

        public bool Cadastrar(Cliente c)
        {
            bool Aux_BL = true;
            if (c.Cpf == null)
            {
                Aux_BL = false;
                
            }
            if (c.Nome == null)
            {
                Aux_BL = false;
            }

            if (Aux_BL == true)
            {
                ctx.Clientes.Add(c);
                ctx.SaveChanges();
            }
            
                return Aux_BL;
        }

        public Cliente BuscarPorId(int id)
        {
            return ctx.Clientes.Find(id);
        }

        public List<Cliente> Listar()
        {
            return ctx.Clientes.ToList();
        }
    }
}
