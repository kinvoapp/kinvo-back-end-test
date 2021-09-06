using KinvoTeste.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace KinvoTeste.Data
{
    public class UsuarioRepository
    {
        public int Add(Usuario usuario)
        {
            using (var dbContext = new Context())
            {
                dbContext.Usuarios.Add(usuario);
                dbContext.SaveChanges();
                return usuario.Id;
            }
        }

        public List<Usuario> GetAll()
        {
            using (var dbContext = new Context())
            {
                return dbContext.Usuarios
                    .Include(x => x.Contas)
                    .Include(x => x.Produtos)
                    .ToList();
            }
        }

        public Usuario Get(int id)
        {
            using (var dbContext = new Context())
            {
                return dbContext.Usuarios
                    .Include(x => x.Contas)
                    .Include(x => x.Produtos)
                    .FirstOrDefault(x => x.Id == id);
            }
        }

        public void Update(int id, Usuario usuario)
        {
            using (var dbContext = new Context())
            {
                var usu = dbContext.Usuarios.FirstOrDefault(x => x.Id == id);
                usu.Login = usuario.Login;
                usu.Senha = usuario.Senha;
                dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var dbContext = new Context())
            {
                var usu = dbContext.Usuarios.FirstOrDefault(x => x.Id == id);
                dbContext.Usuarios.Remove(usu);
                dbContext.SaveChanges();
            }
        }

        public Usuario Login(string login, string senha)
        {
            using (var dbContext = new Context())
            {
                return dbContext.Usuarios
                    .Include(x => x.Contas)
                    .Include(x => x.Produtos)
                    .FirstOrDefault(x => x.Login == login && x.Senha == senha);
            }
        }
    }
}
