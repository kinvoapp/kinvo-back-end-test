using Aliquota.Domain.AggregatesModel.Usuario;
using System.Linq;

namespace Aliquota.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AliquotaContext context;

        public UsuarioRepository(AliquotaContext context)
        {
            this.context = context;
        }

        public Usuario Add(Usuario usuario)
        {
            return context.usuarios.Add(usuario).Entity;
        }

        public void Update(Usuario usuario)
        {
            context.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public Usuario GetUsuarioById(int id)
        {
            Usuario usuario = context.usuarios
                .Where(x => x.Id == id)
                .FirstOrDefault();

            return usuario;
        }

        public void Remove(Usuario usuario)
        {
            context.Remove(usuario);
        }
    }
}
