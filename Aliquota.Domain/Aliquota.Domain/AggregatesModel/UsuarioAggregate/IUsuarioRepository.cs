namespace Aliquota.Domain.AggregatesModel.Usuario
{
    public interface IUsuarioRepository
    {
        public Usuario Add(Usuario usuario);

        public void Update(Usuario usuario);

        public Usuario GetUsuarioById(int id);

        public void Remove(Usuario usuario);
    }
}
