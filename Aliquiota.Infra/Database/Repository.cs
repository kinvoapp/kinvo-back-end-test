using Aliquiota.Infra.Database.Context;
using Aliquota.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aliquiota.Infra.Database
{
    public class Repository : IRepository
    {

        private readonly EFContext context;

        public Repository()
        {
            this.context = new EFContext();
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            context.Usuarios.Add(usuario);

            context.SaveChanges();
        }

        public Usuario GetUsuario(int userId)
        {
            return context.Usuarios.AsNoTracking().Include(p => p.Aplicacoes).SingleOrDefault(x => x.Id == userId);
        }

        public IEnumerable<Aplicacao> ListAplicacao()
        {
            return context.Aplicacoes;
        }

        public void SalvarUsuario(Usuario usuario)
        {
            context.Usuarios.Update(usuario);

            context.SaveChanges();
        }
    }
}
