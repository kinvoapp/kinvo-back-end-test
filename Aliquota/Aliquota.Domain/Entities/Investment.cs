using System;
using Aliquota.Domain.Common;

namespace Aliquota.Domain.Entities
{
    /// <summary>
    /// Class que define um investimento
    /// </summary>
    public class Investment : BaseEntity
    {
        public Investment(decimal amount, DateTime start, decimal financialProductId)
        {
            Amount = amount;
            Start = start;
            FinancialProductId = financialProductId;
        }

        public Investment()
        {
        }

        /// <summary>
        /// Quantidade de dinheiro investida
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Lucro até momento corrente
        /// </summary>
        public decimal Profit =>
            Amount * (FinancialProduct.MonthlyIncome / 30) * (decimal) (DateTime.Now - Start).TotalDays;

        /// <summary>
        /// Data início do investimento
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Identificador do fundo/ação no qual o investimento foi feito
        /// </summary>
        public decimal FinancialProductId { get; set; }

        public FinancialProduct FinancialProduct { get; set; }
    }
}