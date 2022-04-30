
namespace Aliquota.Domain.Dominios.Shared
{
    public abstract class EntidadeBase
    {
        public int Id { get; set; }
        public abstract string Validar();
    }
}
