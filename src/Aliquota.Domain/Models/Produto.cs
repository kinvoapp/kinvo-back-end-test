using Aliquota.Domain.Models.Validations;

namespace Aliquota.Domain.Models
{
    public class Produto : Entity
    {
        public string Nome { get; set; }
        public decimal Rentabilidade { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<Posicao> Posicoes { get; set; }

        public Produto(){ }

        public Produto(Guid id, string nome, decimal rentabilidade, bool ativo, DateTime datacadastro)
        {
            Id = id;
            Nome = nome;
            Rentabilidade = rentabilidade;
            Ativo = ativo;
            DataCadastro = datacadastro;
        }
    }
}
