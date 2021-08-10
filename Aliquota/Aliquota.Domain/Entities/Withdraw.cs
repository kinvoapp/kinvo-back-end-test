using System;
using System.Collections.Generic;
using System.Text;
using Aliquota.Domain.Common;

namespace Aliquota.Domain.Entities
{
    public class Withdraw : BaseEntity
    {
        /// <summary>
        /// Quantidade inicial investida
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Porcentagem do Imposto de renda
        /// </summary>
        public decimal TaxPercentage { get; set; }

        /// <summary>
        /// Valor descontado pelo Imposto de Renda
        /// </summary>
        public decimal TaxAmount { get; set; }

        /// <summary>
        /// Tempo que ficou investido
        /// </summary>
        public decimal InvestedTime { get; set; }

        /// <summary>
        /// Lucro líquido
        /// </summary>
        public decimal LiquidIncome { get; set; }

        /// <summary>
        /// Lucro
        /// </summary>
        public decimal Profit { get; set; }

        /// <summary>
        /// Quando começou o investimento
        /// </summary>
        public DateTime Start { get; set; }
    }
}