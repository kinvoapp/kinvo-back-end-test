using Aliquota.CrossCuting;

namespace Aliquota.Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoCliente Tipo { get; set; }
    }
}
