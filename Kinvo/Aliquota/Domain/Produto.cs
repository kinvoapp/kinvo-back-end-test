using System;

namespace Aliquota.Domain
{
  public  class Produto
    {
        /// <summary>
        /// Identififcador
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome do Produto
        /// </summary>
        public string Nome { get; set; } 
        /// <summary>
        /// Saldo Corrente
        /// </summary>
        public decimal Saldo { get; set; }
        /// <summary>
        /// Percentual de Rendimento do Produto
        /// </summary>
        public decimal PercentualRedimento { get; set; }
        /// <summary>
        /// Data Aplicação
        /// </summary>
        public DateTime Data { get; set; }

    }
}
