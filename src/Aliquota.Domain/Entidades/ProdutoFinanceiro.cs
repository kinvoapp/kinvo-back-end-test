using Aliquota.Domain.Entidades.Base;
using System.Collections.Generic;

namespace Aliquota.Domain.Entidades
{
    /// <summary>
    /// Entidade principal para uma aplicação financeira.
    /// Esta é a entidade que contém as propriedades de chave primária/alternativa (Id na EntidadeBase).
    /// Às vezes, chamado de 'pai' da relação.
    /// </summary>
    public class ProdutoFinanceiro : EntidadeBase
    {
        public string Nome { get; private set; }
        public decimal ValorCotacao { get; private set; }
        public decimal RendimentoMensal { get; private set; }

        /// <summary>
        /// Propriedade de navegação de coleção, onde contém referências
        /// a muitas aplicações financeiras
        /// </summary>
        public IList<AplicacaoFinanceira> AplicacoesFinanceiras { get; private set; }

        public ProdutoFinanceiro(
            string nome,
            decimal valorCotacao,
            decimal rendimentoMensal)
        {
            Nome = nome;
            ValorCotacao = valorCotacao;
            RendimentoMensal = rendimentoMensal;
        }
    }
}