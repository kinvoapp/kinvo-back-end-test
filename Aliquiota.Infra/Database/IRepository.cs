using System.Collections.Generic;
using Aliquota.Domain;

namespace Aliquiota.Infra.Database
{
    public interface IRepository
    {
        Usuario GetUsuario(int userId);
        void SalvarUsuario(Usuario usuario);
        void AdicionarUsuario(Usuario usuario);
    }
}