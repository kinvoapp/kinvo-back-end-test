using Aliquota.Domain.Entidades.Base;
using System;

namespace Aliquota.Domain.Entidades
{
    /// <summary>
    /// Entidade dependente para uma aplicação financeira.
    /// Essa é a entidade que contém as propriedades de chave estrangeira (Id na EntidadeBase).
    /// Às vezes, chamado de 'filho' da relação.
    /// </summary>
    public class AplicacaoFinanceira : EntidadeBase
    {
        public DateTime DataAplicacao { get; private set; }
        public decimal ValorAplicacao { get; private set; }
        public decimal Quantidade { get; private set; }

        /// <summary>
        /// Propriedade de chave estrangeira para um produto financeiro
        /// </summary>
        public Guid ProdutoFinanceiroId { get; private set; }

        /// <summary>
        /// Propriedade de navegação  de referência, que mantém uma
        /// referência a uma única entidade relacionada.
        /// Ela é também uma propriedade de navegação inversa de
        /// ProdutoFinanceiro.AplicacoesFinanceiras (e vice-versa)
        /// </summary>
        public virtual ProdutoFinanceiro ProdutoFinanceiro { get; private set; }

        public decimal Lucro
        {
            get
            {
                if (ProdutoFinanceiro == null)
                    return 0;

                var dias = (int)DateTime.Now.Date.Subtract(DataAplicacao).TotalDays;
                return ((ValorAplicacao * (ProdutoFinanceiro.RendimentoMensal / 30)) * dias);
            }
        }

        protected AplicacaoFinanceira()
        {
        }

        public AplicacaoFinanceira(
            DateTime dataAplicacao,
            decimal valorAplicacao,
            decimal quantidade,
            Guid produtoFinanceiroId)
        {
            DataAplicacao = dataAplicacao;
            Quantidade = quantidade;
            ValorAplicacao = valorAplicacao;
            ProdutoFinanceiroId = produtoFinanceiroId;
        }
    }
}