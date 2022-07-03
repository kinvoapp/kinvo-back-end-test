namespace Aliquota.Domain.Models
{
    public class Produto : Entity
    {
        public string Nome { get; set; }
        public decimal Rentabilidade { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<Posicao> Posicoes { get; set; }
    }
}
