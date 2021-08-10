using Aliquota.Domain.Common;
using Aliquota.Domain.Enums;

namespace Aliquota.Domain.Entities
{
    /// <summary>
    /// Classe que define um fundo/ação
    /// </summary>
    public class FinancialProduct : BaseEntity
    {
        public FinancialProduct(string name, decimal monthlyIncome, Profitability profitability, Deadline deadline, decimal minimalInvestedAmount)
        {
            Name = name;
            MonthlyIncome = monthlyIncome;
            Profitability = profitability;
            Deadline = deadline;
            MinimalInvestedAmount = minimalInvestedAmount;
        }

        /// <summary>
        /// Nome do fundo
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Quantidade mínima a ser investida
        /// </summary>
        /// <remarks>
        /// Você só conseque investir nesse fundo caso o valor seja maior ou igual ao <see cref="MinimalInvestedAmount"/>
        /// </remarks>
        public decimal MinimalInvestedAmount { get; set; }

        /// <summary>
        /// Rendimento mensal
        /// </summary>
        /// <remarks>
        /// Quanto o fundo/ação varia mensalmente
        /// </remarks>
        public decimal MonthlyIncome { get; set; }

        /// <summary>
        /// Rentabilidade do fundo
        /// </summary>
        public Profitability Profitability { get; set; }

        /// <summary>
        /// Data do vencimento
        /// </summary>
        /// <remarks>
        /// O investimento só pode ser retirado após esse tempo ter passado
        /// </remarks>
        public Deadline Deadline { get; set; }

    }
}
