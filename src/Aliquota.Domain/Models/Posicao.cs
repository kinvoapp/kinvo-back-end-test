namespace Aliquota.Domain.Models
{
    public class Posicao : Entity
    {
        public Guid ProdutoId { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAporte { get; set; }
        public DateTime? DataResgate { get; set; }
        public decimal ValorAportado { get; set; }
        public decimal? ValorResgatado { get; set; }
        public decimal? ValorTributado { get; set; }
        public bool Ativo { get; set; }
        public Produto Produto { get; set; }

    }
}
